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
    public class KnjigaPisac : IEntity
    {
        public Knjiga Knjiga { get; set; }
        public Pisac Pisac { get; set; }

        public string TableName => "KnjigaPisac";

        public string Values => $"{Knjiga.KnjigaId}, {Pisac.PisacId}";

        public string ColumnNames => "KnjigaId, PisacId";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> knjigaPisacList = new List<IEntity>();
            try
            {
                while (reader.Read())
                {
                    KnjigaPisac kp = new KnjigaPisac
                    {
                        Knjiga = new Knjiga { KnjigaId = (int)reader["KnjigaId"] },
                        Pisac = new Pisac { PisacId = (int)reader["PisacId"] }
                    };
                    knjigaPisacList.Add(kp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return knjigaPisacList;
        }
    }
}
