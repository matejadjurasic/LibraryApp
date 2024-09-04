using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Domain;

namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;
        public Broker()
        {
            connection = new DbConnection();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }
        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public Korisnik Login(Korisnik k)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Korisnik where KorisnickoIme='{k.KorisnickoIme}' and Sifra='{k.Sifra}'";
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    k.Ime = reader["Ime"].ToString();
                    k.Prezime = reader["Prezime"].ToString();
                    k.KorisnikId = (int)reader["KorisnikID"];
                    return k;
                }
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            finally { reader.Close(); }
            return null;
        }
        public Bibliotekar LoginB(Bibliotekar b)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Bibliotekar where KorisnickoIme='{b.KorisnickoIme}' and Sifra='{b.Sifra}'";
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    b.Ime = reader["Ime"].ToString();
                    b.Prezime = reader["Prezime"].ToString();
                    b.BibliotekarId = (int)reader["BibliotekarID"];
                    return b;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally { reader.Close(); }
            return null;
        }

        public int AddEntity(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO {entity.TableName}({entity.ColumnNames}) VALUES({entity.Values}); SELECT SCOPE_IDENTITY();";
            try
            {
                int newId = Convert.ToInt32(command.ExecuteScalar());
                return newId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        public bool UpdateEntity(IEntity entity, int entityId)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE {entity.TableName} SET {GetUpdateSetClause(entity)} WHERE {entity.TableName}Id = {entityId}";
            
            foreach (var property in entity.GetType().GetProperties())
            {
                if (property.Name != $"{entity.TableName}Id" && property.Name != "Pisci" && property.Name != "Stavke")
                {
                    var value = property.GetValue(entity) ?? DBNull.Value;
                    command.Parameters.AddWithValue($"@{property.Name}", value);
                }
            }
            Debug.WriteLine(command.CommandText);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private string GetUpdateSetClause(IEntity entity)
        {
            var setClauses = new List<string>();
            var properties = entity.GetType().GetProperties();
            var excludedProperties = new HashSet<string> { "TableName", "Values", "ColumnNames", $"{entity.TableName}Id", "Pisci","Stavke" };

            foreach (var property in properties)
            {
                if (!excludedProperties.Contains(property.Name)) 
                {
                    setClauses.Add($"{property.Name} = @{property.Name}");
                }
            }

            return string.Join(", ", setClauses);
        }


        public bool DeleteEntity(IEntity entity, int entityId)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.TableName}Id = {entityId}";
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public IEntity GetEntity(IEntity entity, int entityId)
        {
            IEntity resultEntity = null;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName} WHERE {entity.TableName}Id = {entityId}";
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                List<IEntity> entities = entity.GetReaderList(reader);
                if (entities.Count > 0)
                {
                    resultEntity = entities.First();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return resultEntity;
        }

        public List<IEntity> GetAllEntities(IEntity entity)
        {
            List<IEntity> entities = new List<IEntity>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName}";
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                entities = entity.GetReaderList(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return entities;
        }

        public List<IEntity> SearchEntities(IEntity entity, string searchValue)
        {
            List<IEntity> entities = new List<IEntity>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName} WHERE Ime LIKE '%{searchValue}%'";
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                entities = entity.GetReaderList(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return entities;
        }

        public bool DeleteBookWriters(int knjigaId)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM KnjigaPisac WHERE KnjigaId = {knjigaId}";

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public List<IEntity> GetWritersForBook(int knjigaId)
        {
            List<IEntity> writers = new List<IEntity>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                        SELECT p.PisacId, p.Ime, p.Prezime
                        FROM Pisac p
                        INNER JOIN KnjigaPisac kp ON p.PisacId = kp.PisacId
                        WHERE kp.KnjigaId = @KnjigaId";
            command.Parameters.AddWithValue("@KnjigaId", knjigaId);

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                writers = new Pisac().GetReaderList(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }

            return writers;
        }

        public List<IEntity> GetAllConfirmations()
        {
            List<IEntity> confirmations = new List<IEntity>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                SELECT p.PotvrdaId, p.DatumOd, p.Returned,
                    k.KorisnikId, k.Ime AS KorisnikIme, k.Prezime AS KorisnikPrezime, 
                    b.BibliotekarId, b.Ime AS BibliotekarIme, b.Prezime AS BibliotekarPrezime
                FROM Potvrda p
                JOIN Korisnik k ON p.KorisnikId = k.KorisnikId
                JOIN Bibliotekar b ON p.BibliotekarId = b.BibliotekarId";

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                confirmations = new Potvrda().GetReaderList(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return confirmations;
        }

        public List<IEntity> GetConfirmationItems(int potvrdaId)
        {
            List<IEntity> items = new List<IEntity>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                SELECT sp.StavkaId, sp.Kolicina, 
                       k.KnjigaId, k.Ime, k.BrojDostupnihKopija, k.BrojKopija,
                       sp.PotvrdaId
                FROM StavkaPotvrde sp
                JOIN Knjiga k ON sp.KnjigaId = k.KnjigaId
                WHERE sp.PotvrdaId = @PotvrdaId";

            command.Parameters.AddWithValue("@PotvrdaId", potvrdaId);

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                items = new StavkaPotvrde().GetReaderList(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return items;
        }

        public bool UpdateConfirmation(Potvrda potvrda)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE Potvrda 
                SET DatumOd = @DatumOd, 
                    KorisnikId = @KorisnikId, 
                    BibliotekarId = @BibliotekarId,
                    Returned = @Returned 
                WHERE PotvrdaId = @PotvrdaId";

            command.Parameters.AddWithValue("@DatumOd", potvrda.DatumOd);
            command.Parameters.AddWithValue("@KorisnikId", potvrda.Korisnik.KorisnikId);
            command.Parameters.AddWithValue("@BibliotekarId", potvrda.Bibliotekar.BibliotekarId);
            command.Parameters.AddWithValue("@Returned", potvrda.Returned);
            command.Parameters.AddWithValue("@PotvrdaId", potvrda.PotvrdaId);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
