using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TranslationCrawler
{
    public class FolderHandler : IFolderHandler
    {
        private readonly string _applicationName = "TestDec";

        private string _baseSourcePath;
        public string GetBaseSource()
        {
            if (_baseSourcePath != null)
            {
                return _baseSourcePath;
            }

            var baseSourceFromConfig = ConfigurationManager.AppSettings["baseSource"];
            if (!string.IsNullOrEmpty(baseSourceFromConfig))
            {
                return baseSourceFromConfig;
            }

            var rootPath = Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\..\");
            var rootDirectory = Path.GetDirectoryName(Path.GetFullPath(rootPath));
            var hardCodedPath = Path.Combine(rootDirectory, _applicationName);
            _baseSourcePath = hardCodedPath;
            return _baseSourcePath;
        }

        public IEnumerable<string> GetAllResourceFiles()
        {
            
            foreach (var filePath in Directory.GetFiles(GetBaseSource(), "*.*", SearchOption.AllDirectories)
                                              .Where(s => s.EndsWith(".aspx") || s.EndsWith(".ascx")))
            {
                yield return GetRelativeFilePath(filePath);
            }
        }

        public string GetRelativeFilePath(string fileFullPath)
        {
            var baseSourceLength = GetBaseSource().Length + 1;
            var relativeFilePath = fileFullPath.Substring(baseSourceLength, fileFullPath.Length - baseSourceLength);
            return relativeFilePath;
        }

        public IEnumerable<string> GetAllResourceFullFiles()
        {
            foreach (var filePath in Directory.GetFiles(GetBaseSource(), "*.*", SearchOption.AllDirectories)
                                              .Where(s => s.EndsWith(".aspx") || s.EndsWith(".ascx")))
            {
                    yield return filePath;
            }
        }
    }
}
