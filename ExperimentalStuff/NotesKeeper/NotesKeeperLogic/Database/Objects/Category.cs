using System;
using System.Collections.Generic;
using System.Text;

namespace NotesKeeperLogic.Database.Objects
{
    public class Category : DbObject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public DateTime CreationDate { get; set; }
        public string ColorCode { get; set; }
    }
}
