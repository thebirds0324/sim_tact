using SQLite;

namespace CartProject.Services
{
    public interface ISQLite
    {
       SQLiteAsyncConnection GetConnection();
    }
}
