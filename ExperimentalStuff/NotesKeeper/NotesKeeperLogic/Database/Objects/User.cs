using System;
using System.Collections.Generic;
using System.Text;

namespace NotesKeeperLogic.Database.Objects
{
    public class User : DbObject
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
