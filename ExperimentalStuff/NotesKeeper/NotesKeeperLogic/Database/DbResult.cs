using NotesKeeperLogic.Database.Objects;
using System;
using System.Collections.Generic;

namespace NotesKeeperLogic.Database
{
    public class DbResult
    {
        public DbResult(Exception ex, string message = null)
        {
            Status = false;
            Exception = ex;

            if (message == null)
                Message = ex.Message;
            else
                Message = message;
        }

        public DbResult(string message, IEnumerable<DbObject> data = null)
        {
            Status = true;
            Message = $"{DateTime.Now} - {message} {Environment.NewLine}";

            if (data != null)
                Data = data;
        }

        public void AddMessage(string message, MessageType type)
        {
            Message += $"{DateTime.Now} - {type.ToString()} - {message} {Environment.NewLine}";
        }

        public bool Status { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
        public IEnumerable<DbObject> Data { get; set; }
    }
}