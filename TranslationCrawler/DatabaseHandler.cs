namespace TranslationCrawler
{
    public class DatabaseHandler
    {
        private string _connectionString;
        public DatabaseHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveTranslationMovingHistory(string sourceRelativePath, string destinationRelativePath, string resourceKey, string language)
        {

        }
    }
}
