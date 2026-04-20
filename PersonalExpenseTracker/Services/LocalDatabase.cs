using SQLite;
using PersonalExpenseTracker.Constants;
using PersonalExpenseTracker.Models;

namespace PersonalExpenseTracker.Services
{
    /// <summary>
    /// Manages the SQLiteAsyncConnection singleton and ensures tables are created.
    /// </summary>
    public class LocalDatabase
    {
        private SQLiteAsyncConnection _database;

        public async Task<SQLiteAsyncConnection> GetDatabaseAsync()
        {
            if (_database is null)
            {
                _database = new SQLiteAsyncConnection(
                    DatabaseConstants.DatabasePath,
                    DatabaseConstants.Flags);

                // Create tables if they do not already exist
                await _database.CreateTableAsync<Category>();
                await _database.CreateTableAsync<Expense>();
            }

            return _database;
        }
    }
}
