using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CartProject.Models;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace CartProject.Services
{
    public class SQLiteService
    {
        private static SQLiteService instance;
        public static SQLiteService Instance
        {
            get => instance ?? (instance = new SQLiteService());
        }

        private static SQLiteAsyncConnection _database;
        public SQLiteService()
        {
            _database = DependencyService.Get<ISQLite>().GetConnection();
            _database.CreateTableAsync<Ads>().Wait();
        }

        #region DB Task Method들
        public Task<List<Ads>> GetAdsSAsync()
        {
            return _database.Table<Ads>().ToListAsync();
        }  //Items
        public Task<Ads> GetAdsAsync(int id)
        {
            return _database.Table<Ads>().Where(i => i.ID == id).FirstOrDefaultAsync();
        } //Item

        public Task<int> SaveAdsAsync(Ads ads)
        {
            if (ads.ID != 0)
            {
                return _database.UpdateAsync(ads);
            }
            else
            {
                return _database.InsertAsync(ads);
            }
        }
        public Task<int> DeleteAdsAsync(Ads ads)
        {
            return _database.DeleteAsync(ads);
        }

        #endregion

    }
}
