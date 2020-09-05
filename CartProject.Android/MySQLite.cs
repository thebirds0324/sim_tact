using Xamarin.Forms;
using SQLite;
using CartProject.Droid;
using CartProject.Services;
using System.IO;

[assembly: Dependency(typeof(MySQLite))]
namespace CartProject.Droid
{
    class MySQLite : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(document, "MySQLite.db");

            return new SQLiteAsyncConnection(path);
        }
    }
}