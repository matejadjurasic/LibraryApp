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
    public class Pisac : IEntity
    {
        public int PisacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string TableName => "Pisac";
        public string ColumnNames => "Ime,Prezime";
        public string Values => $"'{Ime}','{Prezime}'";

        public override bool Equals(object obj)
        {
            return obj is Pisac pisac &&
                   PisacId == pisac.PisacId;
        }

        public override int GetHashCode()
        {
            return 2131893778 + PisacId.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> pisci = new List<IEntity>();
            try
            {
                while (reader.Read())
                {
                    Pisac pisac = new Pisac
                    {
                        PisacId = (int)reader["PisacId"],
                        Ime = reader["Ime"].ToString(),
                        Prezime = reader["Prezime"].ToString()
                    };
                    pisci.Add(pisac);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return pisci;
        }


        public string GetUpdateValues()
        {
            return "Ime = @Ime, Prezime = @Prezime";
        }

        public string GetUpdateCondition()
        {
            return "PisacId = @PisacId";
        }

        public void SetUpdateParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Ime", Ime);
            command.Parameters.AddWithValue("@Prezime", Prezime);
            command.Parameters.AddWithValue("@PisacId", PisacId);
        }
    }
}
