using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CartProject.Models;
using SQLite;

namespace CartProject.Data
{
    public class AdsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public AdsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Ads>().Wait();
        }

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
    }
}
