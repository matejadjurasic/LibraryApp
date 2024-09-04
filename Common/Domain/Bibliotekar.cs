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
    }
}
