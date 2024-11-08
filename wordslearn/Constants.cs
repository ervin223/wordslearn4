using System.IO;
using SQLite;

namespace wordslearn
{
    public static class Constants
    {
        public const string DatabaseFilename = "WordsLearnDB.db3";

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;
    }

}
