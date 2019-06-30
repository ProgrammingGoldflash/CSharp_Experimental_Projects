using NotesKeeperLogic.Database.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NotesKeeperLogic.Database
{
    public class DBAccess
    {
        private SqlConnection sql { get; set; }

        public DBAccess(string connectionString)
        {
            sql = new SqlConnection(connectionString);
            sql.Open();
        }

        public DbResult<T> ExecuteQuery<T>(string query, bool debug = false)
        {
            DbResult<T> result;

            try
            {
                result = new DbResult<T>("Start executing query");

                using (var command = new SqlCommand(query, sql))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        List<T> dataList = new List<T>();

                        while(reader.Read())
                        {
                            var instance = (T)Activator.CreateInstance(typeof(T));

                            string message;
                            (instance as DbObject).ConvertDbRowToDbObject(reader, out message);

                            dataList.Add(instance);

                            if (debug)
                                result.AddMessage(message, MessageType.Information);
                        }

                        result.Data = dataList;
                    }
                }
            }
            catch (Exception ex)
            {
                result = new DbResult<T>(ex);
            }

            return result;
        }

    }
}
