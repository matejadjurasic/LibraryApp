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

        public string GetUpdateCondition()
        {
            return "KnjigaId = @KnjigaId, PisacId = @PisacId";
        }

        public string GetUpdateValues()
        {
            return "KnjigaId = @KnjigaId, PisacId = @PisacId";
        }

        public void SetUpdateParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@KnjigaId", Knjiga.KnjigaId);
            command.Parameters.AddWithValue("@PisacId", Pisac.PisacId);
        }

        public string GetPrimaryKeyCondition()
        {
            //return "KnjigaId = @KnjigaId AND PisacId = @PisacId";
            return "KnjigaId = @KnjigaId";
        }

        public void SetPrimaryKeyParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@KnjigaId", Knjiga.KnjigaId);
            //command.Parameters.AddWithValue("@PisacId", Pisac.PisacId);
        }

        public string CustomJoinQuery()
        {
            return null;  
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
