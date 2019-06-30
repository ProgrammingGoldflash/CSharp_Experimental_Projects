using System;
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

        public DbResult ExecuteQuery(string query)
        {
            DbResult result;

            try
            {
                using (var command = new SqlCommand(query, sql))
                {
                    var reader = command.ExecuteReader();
                }

                result = new DbResult("");
            }
            catch (Exception ex)
            {
                result = new DbResult(ex);
            }

            return result;
        }

    }
}
