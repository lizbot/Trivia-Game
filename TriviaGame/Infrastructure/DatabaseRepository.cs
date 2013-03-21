using System.IO;
using System.Reflection;

namespace Infrastructure
{
    public class DatabaseRepository
    {
        public DatabaseRepository()
        {
        }

        public void setUpDatabase()
        {
            //var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "trivia.db");

            //var dbPath = Path.Combine(Assembly.GetEntryAssembly().Location, "trivia.db");
            
            var db = new SQLite.SQLiteConnection (dbPath);
        }
    }
}
