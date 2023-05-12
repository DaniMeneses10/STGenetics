using System.Data.Common;
using System.Data;
using System.Reflection;

namespace STGeneticsProject.Database.Helpers
{
    public class StoredProcedureHelper
    {
        public static List<T> ExecuteStoredProcedure<T>(string storedProcedureName, Dictionary<string, object> parameters, DbConnection conn)
        {
            try
            {
                List<T> objList = new List<T>();
                conn.Open();

                DbCommand command = conn.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var parameter in parameters)
                    {
                        DbParameter param = command.CreateParameter();
                        param.ParameterName = parameter.Key;
                        param.Value = parameter.Value;
                        command.Parameters.Add(param);
                    }
                }

                DbDataReader reader = command.ExecuteReader();
                IEnumerable<PropertyInfo> props = typeof(T).GetRuntimeProperties();
                Dictionary<string, DbColumn> colMapping = reader.GetColumnSchema()
                    .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                    .ToDictionary(key => key.ColumnName.ToLower());

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        T obj = Activator.CreateInstance<T>();
                        foreach (PropertyInfo prop in props)
                        {

                            if (colMapping.ContainsKey(prop.Name.ToLower()))
                            {
                                object val =
                                reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                                prop.SetValue(obj, val == DBNull.Value ? null : val);
                            }

                        }
                        objList.Add(obj);
                    }
                }
                reader.Dispose();
                conn.Close();
                return objList;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw;
            }
        }
    }
}
