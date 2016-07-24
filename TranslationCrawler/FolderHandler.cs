using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TranslationCrawler
{
    public class FolderHandler : IFolderHandler
    {
        private readonly string _applicationName = "TestDec";
        private readonly string _resourceFolderName = "App_LocalResources";
        private readonly string _resourceFileExtension = ".resx";

        // Used only for caching purpose.
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

        public IEnumerable<string> GetAllControlsFiles()
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

        public IEnumerable<string> GetAllControlsFullFilePaths()
        {
            foreach (var filePath in Directory.GetFiles(GetBaseSource(), "*.*", SearchOption.AllDirectories)
                                              .Where(s => s.EndsWith(".aspx") || s.EndsWith(".ascx")))
            {
                yield return filePath;
            }
        }

        public IEnumerable<string> GetAllSourceLanguages(string sourcePath)
        {
            var sourceDirectory = Path.GetDirectoryName(Path.Combine(GetBaseSource(), sourcePath));
            if (sourceDirectory == null || !Directory.Exists(sourceDirectory))
            {
                yield break;
            }

            var resourceDirectory = Path.Combine(sourceDirectory, _resourceFolderName);
            if (!Directory.Exists(resourceDirectory))
            {
                yield break;
            }

            var sourceFile = Path.GetFileName(sourcePath);

            foreach (var resourceFile in Directory.GetFiles(resourceDirectory, sourceFile + "*"))
            {
                if (Path.GetFileName(resourceFile) == sourceFile + _resourceFileExtension)
                {
                    yield return "en";
                    continue;
                }

                var resourceFileWithoutExtension = Path.GetFileNameWithoutExtension(resourceFile);
                var indexOfLastDot = resourceFileWithoutExtension.LastIndexOf('.') + 1;
                var language = resourceFileWithoutExtension.Substring(indexOfLastDot, resourceFileWithoutExtension.Length - indexOfLastDot);
                yield return language;
            }
        }

        public string GetFullPath(string destinationRelativeFilePath)
        {
            var fullPath = Path.Combine(GetBaseSource(), destinationRelativeFilePath);
            return fullPath;
        }

        public string GetResourceFilePath(string sourceRelativeFilePath, string language)
        {
            var controlFilePath = Path.Combine(GetBaseSource(), sourceRelativeFilePath);
            var controlFileName = Path.GetFileName(controlFilePath);

            string expectedResourceFilePath = null;
            if (language == "en")
            {
                expectedResourceFilePath = Path.Combine(Path.GetDirectoryName(controlFilePath), $"{_resourceFolderName}\\{controlFileName}{_resourceFileExtension}");
            }
            else
            {
                expectedResourceFilePath = Path.Combine(Path.GetDirectoryName(controlFilePath), $"{_resourceFolderName}\\{controlFileName}.{language}{_resourceFileExtension}");
            }
            
            return expectedResourceFilePath;
        }
    }
}
