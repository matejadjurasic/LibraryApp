using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Domain;

namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;
        public Broker()
        {
            connection = new DbConnection();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }
        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public int AddEntity(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO {entity.TableName}({entity.ColumnNames}) VALUES({entity.Values}); SELECT SCOPE_IDENTITY();";
            try
            {
                int newId = Convert.ToInt32(command.ExecuteScalar());
                return newId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        public bool UpdateEntity(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE {entity.TableName} SET {entity.GetUpdateValues()} WHERE {entity.GetUpdateCondition()}";

            entity.SetUpdateParameters(command);

            Debug.WriteLine(command.CommandText);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteEntity(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.GetPrimaryKeyCondition()}";
            entity.SetPrimaryKeyParameters(command);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public IEntity GetEntity(IEntity entity)
        {
            IEntity resultEntity = null;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName} WHERE {entity.GetPrimaryKeyCondition()}";
            entity.SetPrimaryKeyParameters(command);

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                List<IEntity> entities = entity.GetReaderList(reader);
                if (entities.Count > 0)
                {
                    resultEntity = entities.First();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return resultEntity;
        }

        public List<IEntity> GetAllEntities(IEntity entity)
        {
            List<IEntity> entities = new List<IEntity>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName}";
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                entities = entity.GetReaderList(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return entities;
        }

        public List<IEntity> SearchEntities(IEntity entity, string searchValue)
        {
            List<IEntity> entities = new List<IEntity>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName} WHERE Ime LIKE '%{searchValue}%'";
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                entities = entity.GetReaderList(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            if(entities.Count == 0)
            {
                return null;
            }
            return entities;
        }

        public List<IEntity> GetAllEntitiesWithCondition(IEntity entity, params object[] conditions)
        {
            List<IEntity> entities = new List<IEntity>();
            SqlCommand command = connection.CreateCommand();

            if (!string.IsNullOrEmpty(entity.CustomJoinQuery()))
            {
                command.CommandText = entity.CustomJoinQuery();
            }
            else
            {
                command.CommandText = $"SELECT * FROM {entity.TableName}";
            }

            if (!string.IsNullOrEmpty(entity.CustomWhereClause()))
            {
                command.CommandText += " WHERE " + entity.CustomWhereClause();
                entity.SetWhereParameters(command, conditions); 
            }

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                entities = entity.GetReaderList(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return entities;
        }

    }
}
