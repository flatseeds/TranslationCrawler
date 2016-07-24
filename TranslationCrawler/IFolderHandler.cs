using System.Collections.Generic;

namespace TranslationCrawler
{
    public interface IFolderHandler
    {
        string GetBaseSource();
        IEnumerable<string> GetAllControlsFiles();
        IEnumerable<string> GetAllControlsFullFilePaths();
        string GetRelativeFilePath(string fileFullPath);
        string GetFullPath(string destinationRelativeFilePath);
        string GetResourceFilePath(string sourceRelativeFilePath, string language);
    }
}