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
        private string _solutionFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                                            .Replace(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, @"bin\Debug"), string.Empty);

        [TestMethod]
        public void GetBaseSource_AppConfig()
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
        public void GetBaseSource_Default()
        {
            var folderHandler = new FolderHandler();

            var baseSource = folderHandler.GetBaseSource();

            Assert.AreEqual(Path.Combine(_solutionFolder, "TestDec"), baseSource);
        }

        [TestMethod]
        public void GetAllResourceFullFiles_Count()
        {
            var folderHandler = new FolderHandler();

            var resourceFiles = folderHandler.GetAllResourceFullFiles().ToList();

            Assert.AreEqual(10, resourceFiles.Count);

            // Check if paths are really full paths.
            Assert.AreEqual(69, resourceFiles[0].Length);
            Assert.AreEqual(71, resourceFiles[1].Length);
        }

        [TestMethod]
        public void GetAllResourceFiles_Count()
        {
            var folderHandler = new FolderHandler();

            var resourceFiles = folderHandler.GetAllResourceFiles().ToList();

            Assert.AreEqual(10, resourceFiles.Count);

            // Check if paths are really relative paths.
            Assert.AreEqual(10, resourceFiles[0].Length);
            Assert.AreEqual(12, resourceFiles[1].Length);
        }

        [TestMethod]
        public void GetRelativeFilePath()
        {
            //var folderHandlerMoq = new Moq.Mock<IFolderHandler>() { CallBase = true };
            //folderHandlerMoq.Setup(m => m.GetAllResourceFullFiles()).Returns(new List<string>{""});
            //folderHandlerMoq.Setup(m => m.GetBaseSource()).Returns(@"C:\Users\drazenp86\Source\Repos\TranslationCrawler\TestDec");

            var folderHandler = new FolderHandler();

            var resourceRelativeFilePath =
                folderHandler.GetFileRelativePath(Path.Combine(_solutionFolder, @"TestDec\UserControls\TestUC.ascx"));
                    //@"C:\Users\drazenp86\Source\Repos\TranslationCrawler\TestDec\UserControls\TestUC.ascx");

            Assert.AreEqual(@"UserControls\TestUC.ascx", resourceRelativeFilePath);
        }
    }
}
