using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;


namespace wordslearn
{
    public class WordDatabase
    {
        private SQLiteAsyncConnection _database;

        public WordDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WordView>().Wait();
        }

        public Task<List<WordView>> GetWordsAsync()
        {
            return _database.Table<WordView>().ToListAsync();
        }

        public Task<int> SaveWordAsync(WordView word)
        {
            if (word.ID != 0)
            {
                return _database.UpdateAsync(word);
            }
            else
            {
                return _database.InsertAsync(word);
            }
        }

        public Task<int> DeleteWordAsync(WordView word)
        {
            return _database.DeleteAsync(word);
        }

        public Task<WordView> GetWordAsync(int id)
        {
            return _database.Table<WordView>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
    }
}
