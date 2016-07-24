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
        private readonly string ResourceFolderName = "App_LocalResources";
        private readonly string ResourceFileExtension = ".resx";

        public TranslationCrawler()
        {
            InitializeComponent();

            this.txtBaseSource.Text = @"C:\Users\Drazen\Source\Repos\TranslationCrawler\TestDec";
            this.txtSourcePath.Text = @"Account\Login.aspx";
            this.txtDesinationPath.Text = @"UserControls\TestUC.ascx";
        }

        private void btnCrawl_Click(object sender, EventArgs e)
        {
            var sourceControlPath = GetControlPath(txtDesinationPath.Text);
            if (sourceControlPath == null) return;

            var content = File.ReadAllText(sourceControlPath);

            this.lbxTranslations.Items.Clear();
            string patternMetaResourceKeys = "meta:resourcekey=\"(.*?)\"";
            FindResourceKeys(content, patternMetaResourceKeys);

            string patternMaskLocalResource = "GetMaskedLocalResource\\(\"(.*?)\"";
            FindResourceKeys(content, patternMaskLocalResource);
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

        private void FindResourceKeys(string content, string pattern)
        {
            foreach (Match m in Regex.Matches(content, pattern))
            {
                if (m.Groups.Count == 2)
                {
                    this.lbxTranslations.Items.Add(m.Groups[1].Value);
                }
            }
        }

        private void btnCopyTranslation_Click(object sender, EventArgs e)
        {
            GetControlResourceFilePath(txtSourcePath.Text);
        }

        private string GetControlResourceFilePath(string controlPath)
        {
            var sourceControlFullPath = GetControlPath(controlPath);
            if (sourceControlFullPath == null) return null;

            var resourceDirectory = Path.GetDirectoryName(sourceControlFullPath);
            var sourceControlName = Path.GetFileName(sourceControlFullPath);


            var destinationControlFullPath = GetControlPath(controlPath);
            if (destinationControlFullPath == null) return null;

            var destonationResourceDirectory = Path.GetDirectoryName(destinationControlFullPath);
            var destinationControlName = Path.GetFileName(destinationControlFullPath);

            foreach (var resourceFile in GetReourceFiles(resourceDirectory, sourceControlName + ResourceFileExtension))
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
                        ResourceFolderName + "\\" + destinationControlName + ResourceFileExtension);
                using (ResXResourceWriter resx = new ResXResourceWriter(destinationResourceFilePath))
                {
                    foreach(var resource in resourcesToCopy)
                    {
                        resx.AddResource(resource.Key, resource.Value);
                    }
                    
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
            foreach (var resourceFile in Directory.EnumerateFiles(Path.Combine(resourceDirectory, ResourceFolderName)))
            {
                if (resourceFile.Contains(controlName))
                {
                    yield return resourceFile;
                }
            }
        }
    }
}
