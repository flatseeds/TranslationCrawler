using System.Collections.Specialized;
using System.Configuration.Fakes;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.QualityTools.Testing.Fakes.ShimsContext;

namespace TranslationCrawler.Test
{
    [TestClass]
    public class FolderHandlerTest
    {
        // TODO: Get real root directory instead: C:\Users\drazenp86\Source\Repos\TranslationCrawler\TestDec.
        [TestMethod]
        public void GetBaseSource_AppConfig()
        {
            using (Create())
            {
                ShimConfigurationManager.AppSettingsGet = () => new NameValueCollection { { "baseSource", @"C:\Users\drazenp86\Source\Repos\TranslationCrawler\TestDec" } };

                var folderHandler = new FolderHandler();

                var baseSource = folderHandler.GetBaseSource();

                Assert.AreEqual(@"C:\Users\drazenp86\Source\Repos\TranslationCrawler\TestDec", baseSource);
            }
        }

        [TestMethod]
        public void GetBaseSource_Default()
        {
            var folderHandler = new FolderHandler();

            var baseSource = folderHandler.GetBaseSource();
             
            Assert.AreEqual(@"C:\Users\drazenp86\Source\Repos\TranslationCrawler\TestDec", baseSource);
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
                folderHandler.GetFileRelativePath(
                    @"C:\Users\drazenp86\Source\Repos\TranslationCrawler\TestDec\UserControls\TestUC.ascx");

            Assert.AreEqual(@"UserControls\TestUC.ascx", resourceRelativeFilePath);
        }
    }
}
