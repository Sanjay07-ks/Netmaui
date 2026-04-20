using SQLite;

namespace PersonalExpenseTracker.Constants
{
    public static class DatabaseConstants
    {
        public const string DatabaseFilename = "ExpenseTracker.db3";

        public const SQLiteOpenFlags Flags =
            // Open the database in read/write mode
            SQLiteOpenFlags.ReadWrite |
            // Create the database if it doesn't exist
            SQLiteOpenFlags.Create |
            // Enable multi-threaded database access
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
