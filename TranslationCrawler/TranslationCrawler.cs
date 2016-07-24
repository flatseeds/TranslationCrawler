using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TranslationCrawler
{
    // TODO: Rename textbox variables - also could be dropbox.
    // TODO: Move crawler implementation to seprate class.
    public partial class TranslationCrawler : Form
    {
        private readonly string _resourceFolderName = "App_LocalResources";
        private readonly string _resourceFileExtension = ".resx";
        private readonly string _allLanguages = "all";

        private readonly FolderHandler _folderHandler;

        public TranslationCrawler()
        {
            InitializeComponent();

            _folderHandler = new FolderHandler();

            txtBaseSource.Text = _folderHandler.GetBaseSource();

            var resourceFiles = _folderHandler.GetAllResourceFiles().OrderBy(r => r).ToArray<object>();
            if (resourceFiles.Length > 0)
            {
                cbxSourcePath.Items.AddRange(resourceFiles);
                cbxSourcePath.SelectedIndex = 1;
                cbxDestinationPath.Items.AddRange(resourceFiles);
                cbxDestinationPath.SelectedIndex = 8;
            }
        }

        private void btnCrawl_Click(object sender, EventArgs e)
        {
            var sourceRelativePath = cbxSourcePath.SelectedItem.ToString();
            if (string.IsNullOrEmpty(sourceRelativePath))
            {
                throw new ApplicationException("Source file must be selected.");
            }

            var sourceControlFullPath = _folderHandler.GetFullPath(sourceRelativePath);         
            var content = File.ReadAllText(sourceControlFullPath);
            var crawler = new Crawler(content);

            lbxTranslations.Items.AddRange(crawler.FindAllResourceKeys().ToArray<object>());
        }

        private string GetControlPath(string controlPath)
        {
            var controlFullPath = Path.Combine(txtBaseSource.Text, controlPath);
            if (!File.Exists(controlFullPath))
            {
                MessageBox.Show($"Path cannot be found - {controlPath}");
                return null;
            }
            return controlFullPath;
        }

        private void btnCopyTranslation_Click(object sender, EventArgs e)
        {
            GetControlResourceFilePath(cbxSourcePath.SelectedItem.ToString());
        }

        private string GetControlResourceFilePath(string controlPath)
        {
            var sourceControlFullPath = GetControlPath(controlPath);
            if (sourceControlFullPath == null) return null;

            var resourceDirectory = Path.GetDirectoryName(sourceControlFullPath);
            var sourceControlName = Path.GetFileName(sourceControlFullPath);


            var destinationControlFullPath = GetControlPath(cbxDestinationPath.SelectedItem.ToString());
            if (destinationControlFullPath == null) return null;

            var destonationResourceDirectory = Path.GetDirectoryName(destinationControlFullPath);
            var destinationControlName = Path.GetFileName(destinationControlFullPath);

            foreach (var resourceFile in GetReourceFiles(resourceDirectory, sourceControlName + _resourceFileExtension))
            {
                var resourcesToCopy = new Dictionary<string, string>();
                using (ResXResourceSet resxSet = new ResXResourceSet(resourceFile))
                {
                    foreach (var destinationControlResource in this.lbxTranslations.Items)
                    {
                        var resourceName = destinationControlResource.ToString();
                        var translation = resxSet.GetString(resourceName);
                        if (translation == null) continue;

                        resourcesToCopy.Add(resourceName, translation);
                    }
                }

                var destinationResourceFilePath = Path.Combine(destonationResourceDirectory,
                        _resourceFolderName + "\\" + destinationControlName + _resourceFileExtension);
                using (ResXResourceWriter resx = new ResXResourceWriter(destinationResourceFilePath))
                {
                    foreach (var resource in resourcesToCopy)
                    {
                        resx.AddResource(resource.Key, resource.Value);
                    }
                    resx.Generate();
                }

                //var sourcerXML = XDocument.Load(resourceFile);
                //var resourceSourceDataElements = sourcerXML.Descendants("data");

                //var resourceDestination = XDocument.Load(Path.Combine(destonationResourceDirectory,
                //    ResourceFolderName + "\\" + destinationControlName + ResourceFileExtension)).Root;

                //foreach (var destinationControlResource in this.lbxTranslations.Items)
                //{
                //    foreach (var resource in resourceSourceDataElements.Where(x => x.Attribute("name").Value.StartsWith(destinationControlResource.ToString())))
                //    {
                //        var resourceKey = resource.Attribute("name").Value;
                //        var resourceValue = resource.Value;

                //        var data = new XElement("data", new XAttribute("name", "resourceKey"), 
                //                                        new XAttribute("xml:space", "preserve"),
                //                            new XElement("value", "resourceValue"));
                //        resourceDestination.Elements().Last().Add(data);
                //    }
                //}
                //resourceDestination.Save(resourceFile + "1");
            }

            return sourceControlFullPath;
        }

        private IEnumerable<string> GetReourceFiles(string resourceDirectory, string controlName)
        {
            foreach (var resourceFile in Directory.EnumerateFiles(Path.Combine(resourceDirectory, _resourceFolderName)))
            {
                if (resourceFile.Contains(controlName))
                {
                    yield return resourceFile;
                }
            }
        }

        private void cbxSourcePath_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sourceRelativeFilePath = ((ComboBox)sender).SelectedItem.ToString();
            cbxLanguages.Items.Clear();
            cbxLanguages.ResetText();

            var sourceLanguages = _folderHandler.GetAllSourceLanguages(sourceRelativeFilePath).ToArray<object>();
            if (sourceLanguages.Any())
            {
                // Add default value for all languaegs.
                cbxLanguages.Items.Add(_allLanguages);
                cbxLanguages.Items.AddRange(sourceLanguages);
                cbxLanguages.SelectedIndex = 0;
            }
        }
    }
}
