using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain { 

    [Serializable]
    public class Knjiga : IEntity
    {
        public int KnjigaId { get; set; }
        public string Ime { get; set; }
        public int BrojKopija { get; set; }
        public int BrojDostupnihKopija { get; set; }
        public List<Pisac> Pisci { get; set; } = new List<Pisac>();

        public string TableName => "Knjiga";
        public string ColumnNames => "Ime,BrojKopija,BrojDostupnihKopija";
        public string Values => $"'{Ime}',{BrojKopija},{BrojDostupnihKopija}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> knjige = new List<IEntity>();
            try
            {
                while (reader.Read())
                {
                    Knjiga knjiga = new Knjiga
                    {
                        KnjigaId = (int)reader["KnjigaId"],
                        Ime = reader["Ime"].ToString(),
                        BrojKopija = (int)reader["BrojKopija"],
                        BrojDostupnihKopija = (int)reader["BrojDostupnihKopija"]
                    };
                    knjige.Add(knjiga);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return knjige;
        }

        public string GetUpdateValues()
        {
            return "Ime = @Ime, BrojKopija = @BrojKopija, BrojDostupnihKopija = @BrojDostupnihKopija";
        }

        public string GetUpdateCondition()
        {
            return "KnjigaId = @KnjigaId";
        }

        public void SetUpdateParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Ime", Ime);
            command.Parameters.AddWithValue("@BrojKopija", BrojKopija);
            command.Parameters.AddWithValue("@BrojDostupnihKopija", BrojDostupnihKopija);
            command.Parameters.AddWithValue("@KnjigaId", KnjigaId);
        }
    }
}
