using NotesKeeperLogic.Database;
using NotesKeeperLogic.Database.Objects;

namespace WindowsApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DBAccess access = new DBAccess("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=NotesKeeper_Testing;Integrated Security=SSPI;");
            access.ExecuteQuery<User>("SELECT * FROM [User]", true);
        }
    }
}
