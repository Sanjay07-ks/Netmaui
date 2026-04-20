using PersonalExpenseTracker.Models;
using SQLite;

namespace PersonalExpenseTracker.Services
{
    public class SQLiteExpenseDataStore : IDataStore<Expense>
    {
        private readonly LocalDatabase _localDatabase;

        public SQLiteExpenseDataStore(LocalDatabase localDatabase)
        {
            _localDatabase = localDatabase;
        }

        private async Task<SQLiteAsyncConnection> GetDb() =>
            await _localDatabase.GetDatabaseAsync();

        public async Task<bool> AddItemAsync(Expense item)
        {
            var db = await GetDb();
            int result = await db.InsertAsync(item);
            return result > 0;
        }

        public async Task<bool> UpdateItemAsync(Expense item)
        {
            var db = await GetDb();
            int result = await db.UpdateAsync(item);
            return result > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var db = await GetDb();
            int result = await db.DeleteAsync<Expense>(id);
            return result > 0;
        }

        public async Task<Expense> GetItemAsync(string id)
        {
            var db = await GetDb();
            return await db.Table<Expense>()
                           .Where(e => e.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Expense>> GetItemsAsync(bool forceRefresh = false)
        {
            var db = await GetDb();
            return await db.Table<Expense>().ToListAsync();
        }
    }
}
