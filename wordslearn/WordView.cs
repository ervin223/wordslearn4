using SQLite;

namespace wordslearn
{
    public class WordView
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Translation { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

    }
}
