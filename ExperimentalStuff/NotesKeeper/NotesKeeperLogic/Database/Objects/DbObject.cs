using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace NotesKeeperLogic.Database.Objects
{
    public abstract class DbObject
    {
        public bool ConvertDbRowToDbObject(SqlDataReader reader, out string message)
        {
            try
            {
                var properties = this.GetType().GetProperties();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var property = properties.FirstOrDefault(x => x.Name == reader.GetName(i));

                    if (property != null)
                    {
                        property.SetValue(this, reader.GetValue(i));
                    }
                }

                message = $"Successfully filled DbObject properties ('{this.GetType().Name}')";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }

            return true;
        }
    }
}
