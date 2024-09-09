using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }
        string ColumnNames { get; }

        string GetUpdateValues();
        string GetUpdateCondition();
        void SetUpdateParameters(SqlCommand command);
        string GetPrimaryKeyCondition();
        string CustomJoinQuery();  
        string CustomWhereClause();  
        void SetWhereParameters(SqlCommand command, params object[] conditions);
        void SetPrimaryKeyParameters(SqlCommand command);
        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
