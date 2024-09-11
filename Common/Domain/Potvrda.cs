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
    public class Potvrda : IEntity
    {
        public int PotvrdaId { get; set; }
        public DateTime DatumOd { get; set; }
        public Korisnik Korisnik { get; set; }
        public Bibliotekar Bibliotekar { get; set; }
        public bool Returned { get; set; }
        public List<StavkaPotvrde> Stavke { get; set; }

        public string TableName => "Potvrda";
        public string ColumnNames => "DatumOd,KorisnikId,BibliotekarId,Returned";
        public string Values => $"'{DatumOd.ToString("yyyyMMdd HH:mm")}',{Korisnik.KorisnikId},{Bibliotekar.BibliotekarId},{(Returned ? 1 : 0)}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> potvrde = new List<IEntity>();
            try
            {
                while (reader.Read())
                {
                    Potvrda potvrda = new Potvrda
                    {
                        PotvrdaId = (int)reader["PotvrdaId"],
                        DatumOd = (DateTime)reader["DatumOd"],
                        Korisnik = new Korisnik
                        {
                            KorisnikId = (int)reader["KorisnikId"],
                            Ime = reader["KorisnikIme"].ToString(),
                            Prezime = reader["KorisnikPrezime"].ToString()
                        },
                        Bibliotekar = new Bibliotekar
                        {
                            BibliotekarId = (int)reader["BibliotekarId"],
                            Ime = reader["BibliotekarIme"].ToString(),
                            Prezime = reader["BibliotekarPrezime"].ToString()
                        },
                        Returned = (bool)reader["Returned"]
                    };
                    potvrde.Add(potvrda);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return potvrde;
        }

        public string GetUpdateValues()
        {
            return "DatumOd = @DatumOd, KorisnikId = @KorisnikId, BibliotekarId = @BibliotekarId, Returned = @Returned";
        }

        public string GetUpdateCondition()
        {
            return "PotvrdaId = @PotvrdaId";
        }

        public void SetUpdateParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@DatumOd", DatumOd);
            command.Parameters.AddWithValue("@KorisnikId", Korisnik.KorisnikId);
            command.Parameters.AddWithValue("@BibliotekarId", Bibliotekar.BibliotekarId);
            command.Parameters.AddWithValue("@Returned", Returned);
            command.Parameters.AddWithValue("@PotvrdaId", PotvrdaId);
        }

        public string GetPrimaryKeyCondition()
        {
            return "PotvrdaId = @PotvrdaId";
        }

        public void SetPrimaryKeyParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@PotvrdaId", PotvrdaId);
        }

        public string CustomJoinQuery()
        {
            return @"
                SELECT p.PotvrdaId, p.DatumOd, p.Returned,
                       k.KorisnikId, k.Ime AS KorisnikIme, k.Prezime AS KorisnikPrezime, 
                       b.BibliotekarId, b.Ime AS BibliotekarIme, b.Prezime AS BibliotekarPrezime
                FROM Potvrda p
                JOIN Korisnik k ON p.KorisnikId = k.KorisnikId
                JOIN Bibliotekar b ON p.BibliotekarId = b.BibliotekarId";
        }

        public string CustomWhereClause()
        {
            return null;
        }

        public void SetWhereParameters(SqlCommand command, params object[] conditions)
        { 
        }

        public string SearchColumn()
        {
            return null;
        }
    }
}
