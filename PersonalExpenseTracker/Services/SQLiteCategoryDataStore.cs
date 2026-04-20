using PersonalExpenseTracker.Models;
using SQLite;

namespace PersonalExpenseTracker.Services
{
    public class SQLiteCategoryDataStore : IDataStore<Category>
    {
        private readonly LocalDatabase _localDatabase;

        public SQLiteCategoryDataStore(LocalDatabase localDatabase)
        {
            _localDatabase = localDatabase;
        }

        private async Task<SQLiteAsyncConnection> GetDb() =>
            await _localDatabase.GetDatabaseAsync();

        public async Task<bool> AddItemAsync(Category item)
        {
            var db = await GetDb();
            int result = await db.InsertAsync(item);
            return result > 0;
        }

        public async Task<bool> UpdateItemAsync(Category item)
        {
            var db = await GetDb();
            int result = await db.UpdateAsync(item);
            return result > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var db = await GetDb();
            int result = await db.DeleteAsync<Category>(id);
            return result > 0;
        }

        public async Task<Category> GetItemAsync(string id)
        {
            var db = await GetDb();
            return await db.Table<Category>()
                           .Where(c => c.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetItemsAsync(bool forceRefresh = false)
        {
            var db = await GetDb();
            return await db.Table<Category>().ToListAsync();
        }
    }
}
