using System.Collections.Generic;

namespace TranslationCrawler
{
    public interface IFolderHandler
    {
        string GetBaseSource();
        IEnumerable<string> GetAllResourceFiles();
        IEnumerable<string> GetAllResourceFullFiles();
        string GetRelativeFilePath(string fileFullPath);
    }
}