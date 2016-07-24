using System.Collections.Specialized;
using System.Configuration.Fakes;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.QualityTools.Testing.Fakes.ShimsContext;

namespace TranslationCrawler.Test
{
    [TestClass]
    public class FolderHandlerTest
    {
        // Get real solution directory instead.
        private readonly string _solutionFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                                                    ?.Replace(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, @"bin\Debug"), string.Empty);

        private readonly string _baseSourceProjectName = "TestDec";

        private readonly string _destinationRelativeFilePath = @"UserControls\TestUC.ascx";
        private readonly string _sourceRelativeFilePath = @"Account\Login.aspx";
        private readonly string _sourceRelativeFilePathWihtoutResourceFolder = @"About.ascx";
        private readonly string _sourceRelativeFilePathResourcesNotExists = @"Account\Manage.aspx";

        [TestMethod]
        public void FolderHandler_GetBaseSource_AppConfig()
        {
            using (Create())
            {
                ShimConfigurationManager.AppSettingsGet = () => new NameValueCollection { { "baseSource", _solutionFolder } };

                var folderHandler = new FolderHandler();

                var baseSource = folderHandler.GetBaseSource();

                Assert.AreEqual(_solutionFolder, baseSource);
            }
        }

        [TestMethod]
        public void FolderHandler_GetBaseSource_Default()
        {
            var folderHandler = new FolderHandler();

            var baseSource = folderHandler.GetBaseSource();

            Assert.AreEqual(Path.Combine(_solutionFolder, _baseSourceProjectName), baseSource);
        }

        [TestMethod]
        public void FolderHandler_GetAllResourceFullFiles_Count()
        {
            var folderHandler = new FolderHandler();

            var resourceFiles = folderHandler.GetAllResourceFullFiles().ToList();

            Assert.AreEqual(10, resourceFiles.Count);

            // Check if paths are really full paths.
            Assert.AreEqual(69, resourceFiles[0].Length);
            Assert.AreEqual(71, resourceFiles[1].Length);
        }

        [TestMethod]
        public void FolderHandler_GetAllResourceFiles_Count()
        {
            var folderHandler = new FolderHandler();

            var resourceFiles = folderHandler.GetAllResourceFiles().ToList();

            Assert.AreEqual(10, resourceFiles.Count);

            // Check if paths are really relative paths.
            Assert.AreEqual(10, resourceFiles[0].Length);
            Assert.AreEqual(12, resourceFiles[1].Length);
        }

        [TestMethod]
        public void FolderHandler_GetRelativeFilePath()
        {
            var folderHandler = new FolderHandler();

            var resourceRelativeFilePath =
                folderHandler.GetRelativeFilePath(Path.Combine(_solutionFolder, _baseSourceProjectName + "\\" + _destinationRelativeFilePath));

            Assert.AreEqual(_destinationRelativeFilePath, resourceRelativeFilePath);
        }

        [TestMethod]
        public void FolderHandler_GetAllSourceLanguages_ResourcesExists()
        {
            var folderHandler = new FolderHandler();
            
            var languages = folderHandler.GetAllSourceLanguages(_sourceRelativeFilePath).ToList();

            Assert.AreEqual(2, languages.Count());

            Assert.AreEqual("de", languages[0]);
            Assert.AreEqual("en", languages[1]);
        }

        [TestMethod]
        public void FolderHandler_GetAllSourceLanguages_ResourceFolderDontExists()
        {
            var folderHandler = new FolderHandler();
            
            var languages = folderHandler.GetAllSourceLanguages(_sourceRelativeFilePathWihtoutResourceFolder).ToList();

            Assert.AreEqual(0, languages.Count());
        }

        [TestMethod]
        public void FolderHandler_GetAllSourceLanguages_ResourcesNotExists()
        {
            var folderHandler = new FolderHandler();
            
            var languages = folderHandler.GetAllSourceLanguages(_sourceRelativeFilePathResourcesNotExists).ToList();

            Assert.AreEqual(0, languages.Count());
        }

        [TestMethod]
        public void FolderHandler_GetFullPath()
        {
            var folderHandler = new FolderHandler();
            
            var fullPath = folderHandler.GetFullPath(_destinationRelativeFilePath);

            Assert.AreEqual(Path.Combine(_solutionFolder, _baseSourceProjectName + "\\" + _destinationRelativeFilePath), fullPath);
        }
    }
}
