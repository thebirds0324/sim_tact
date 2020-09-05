using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using SQLitePCL;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Reflection.Metadata;
using CartProject.Tizen;    
using CartProject.Services;

[assembly: Dependency(typeof(MySQLite))]
namespace CartProject.Tizen
{
    class MySQLite: ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var document = global::Tizen.Applications.Application.Current.DirectoryInfo.Data;
            var path = Path.Combine(document, "MySQLite.db");

            raw.SetProvider(new SQLite3Provider_sqlite3());
            raw.FreezeProvider(true);
            return new SQLiteAsyncConnection(path);
        }
    }
}
