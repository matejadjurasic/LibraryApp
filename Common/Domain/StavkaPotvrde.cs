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
    public class StavkaPotvrde : IEntity
    {
        public int StavkaId { get; set; }
        public int Kolicina {  get; set; }
        public Knjiga Knjiga { get; set; }
        public Potvrda Potvrda { get; set; }

        public string TableName => "StavkaPotvrde";

        public string Values => $"{Kolicina}, {Knjiga.KnjigaId}, {Potvrda.PotvrdaId}";

        public string ColumnNames => "Kolicina, KnjigaId, PotvrdaId";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> stavkePotvrde = new List<IEntity>();
            try
            {
                while (reader.Read())
                {
                    StavkaPotvrde stavka = new StavkaPotvrde
                    {
                        StavkaId = (int)reader["StavkaId"],
                        Kolicina = (int)reader["Kolicina"],
                        Knjiga = new Knjiga { KnjigaId = (int)reader["KnjigaId"],
                                               Ime = reader["Ime"].ToString(),
                                                BrojDostupnihKopija = (int)reader["BrojDostupnihKopija"],
                                                BrojKopija = (int)reader["BrojKopija"]
                        },
                        Potvrda = new Potvrda { PotvrdaId = (int)reader["PotvrdaId"] }
                    };
                    stavkePotvrde.Add(stavka);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return stavkePotvrde;
        }

        public string GetUpdateValues()
        {
            return "KnjigaId = @KnjigaId, PotvrdaId = @PotvrdaId, Kolicina = @Kolicina";
        }

        public string GetUpdateCondition()
        {
            return "StavkaId = @StavkaId";
        }

        public void SetUpdateParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@KnjigaId", Knjiga.KnjigaId);
            command.Parameters.AddWithValue("@PotvrdaId", Potvrda.PotvrdaId);
            command.Parameters.AddWithValue("@Kolicina", Kolicina);
            command.Parameters.AddWithValue("@StavkaId", StavkaId);
        }

    }
}
