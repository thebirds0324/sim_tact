using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CartProject.Models;
using System.Threading.Tasks; //Task 관련 참조

namespace CartProject.Data
{
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ItemDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }  //Items
        public Task<Item> GetItemAsync(int id)
        {
            return _database.Table<Item>().Where(i => i.ID == id).FirstOrDefaultAsync();
        } //Item
        public Task<int> SaveItemAsync(Item item)
        {
            if(item.ID != 0)
            {
                return _database.UpdateAsync(item);
            } 
            else
            {
                return _database.InsertAsync(item);
            }
        }
        public Task<int> DeleteNoteAsync(Item item)
        {
            return _database.DeleteAsync(item);
        }
    }
}
