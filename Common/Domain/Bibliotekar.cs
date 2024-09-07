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
    public class Bibliotekar : IEntity
    {
        public int BibliotekarId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra {  get; set; }

        public string TableName => "Bibliotekar";

        public string Values => $"'{Ime}','{Prezime}','{KorisnickoIme}','{Sifra}'";

        public string ColumnNames => "Ime,Prezime,KorisnickoIme,Sifra";

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> bibliotekari = new List<IEntity>();
            try
            {
                while (reader.Read())
                {
                    Bibliotekar bibliotekar = new Bibliotekar
                    {
                        BibliotekarId = (int)reader["BibliotekarId"],
                        Ime = reader["Ime"].ToString(),
                        Prezime = reader["Prezime"].ToString(),
                        KorisnickoIme = reader["KorisnickoIme"].ToString(),
                        Sifra = reader["Sifra"].ToString()
                    };
                    bibliotekari.Add(bibliotekar);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return bibliotekari; 
        }

        public override bool Equals(object obj)
        {
            return obj is Bibliotekar bibliotekar &&
                   BibliotekarId == bibliotekar.BibliotekarId;
        }

        public override int GetHashCode()
        {
            return -487828820 + BibliotekarId.GetHashCode();
        }

        public string GetUpdateValues()
        {
            return "Ime = @Ime, Prezime = @Prezime, KorisnickoIme = @KorisnickoIme, Sifra = @Sifra";
        }

        public string GetUpdateCondition()
        {
            return "BibliotekarId = @BibliotekarId";
        }

        public void SetUpdateParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Ime", Ime);
            command.Parameters.AddWithValue("@Prezime", Prezime);
            command.Parameters.AddWithValue("@KorisnickoIme", KorisnickoIme);
            command.Parameters.AddWithValue("@Sifra", Sifra);
            command.Parameters.AddWithValue("@BibliotekarId", BibliotekarId);
        }
    }
}
