using System.Data;
using System.Data.SqlClient;

namespace TranslationCrawler
{
    public class DatabaseHandler
    {
        private string _connectionString;
        public DatabaseHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveTranslationMovingHistory(string sourceRelativePath, string destinationRelativePath, string resourceKey, int language)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var query = @"insert into [dbo].[translationhistorytable]([SourceResourceSet],[DestinationResourceSet],[ResourceID],[LCID])
                              values(@SourceResourceSet,@DestinationResourceSet,@ResourceID,@LCID)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@SourceResourceSet", SqlDbType.NVarChar).Value = sourceRelativePath;
                    cmd.Parameters.Add("@DestinationResourceSet", SqlDbType.NVarChar).Value = destinationRelativePath;
                    cmd.Parameters.Add("@ResourceID", SqlDbType.NVarChar).Value = resourceKey;
                    cmd.Parameters.Add("@LCID", SqlDbType.Int).Value = language;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
