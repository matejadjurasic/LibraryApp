using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Korisnik : IEntity
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra {  get; set; }

        public string TableName => "Korisnik";

        public string Values => $"'{Ime}','{Prezime}','{KorisnickoIme}','{Sifra}'";

        public string ColumnNames => "Ime,Prezime,KorisnickoIme,Sifra";

        public override bool Equals(object obj)
        {
            return obj is Korisnik korisnik &&
                   KorisnikId == korisnik.KorisnikId;
        }

        public override int GetHashCode()
        {
            return -1215096106 + KorisnikId.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> korisnici = new List<IEntity>();
            try
            {
                while (reader.Read())
                {
                    Korisnik korisnik = new Korisnik
                    {
                        KorisnikId = (int)reader["KorisnikId"],
                        Ime = reader["Ime"].ToString(),
                        Prezime = reader["Prezime"].ToString(),
                        KorisnickoIme = reader["KorisnickoIme"].ToString(),
                        Sifra = reader["Sifra"].ToString()
                    };
                    korisnici.Add(korisnik);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return korisnici;
        }

        public string GetUpdateValues()
        {
            return "Ime = @Ime, Prezime = @Prezime, KorisnickoIme = @KorisnickoIme, Sifra = @Sifra";
        }

        public string GetUpdateCondition()
        {
            return "KorisnikId = @KorisnikId";
        }

        public void SetUpdateParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Ime", Ime);
            command.Parameters.AddWithValue("@Prezime", Prezime);
            command.Parameters.AddWithValue("@KorisnickoIme", KorisnickoIme);
            command.Parameters.AddWithValue("@Sifra", Sifra);
            command.Parameters.AddWithValue("@KorisnikId", KorisnikId);
        }

        public string GetPrimaryKeyCondition()
        {
            return "KorisnikId = @KorisnikId";
        }

        public void SetPrimaryKeyParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@KorisnikId", KorisnikId);
        }

        public string CustomJoinQuery()
        {
            return null;  
        }

        public string CustomWhereClause()
        {
            return "KorisnickoIme = @KorisnickoIme AND Sifra = @Sifra";
        }

        public void SetWhereParameters(SqlCommand command, params object[] conditions)
        {
            command.Parameters.AddWithValue("@KorisnickoIme", KorisnickoIme);
            command.Parameters.AddWithValue("@Sifra", Sifra);
        }

    }
}
