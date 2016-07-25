using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TranslationCrawler
{
    public partial class TranslationCrawler : Form
    {
        private readonly string _allLanguages = "all";

        private readonly FolderHandler _folderHandler;

        public TranslationCrawler()
        {
            InitializeComponent();

            _folderHandler = new FolderHandler();

            txtBaseSource.Text = _folderHandler.GetBaseSource();

            var resourceFiles = _folderHandler.GetAllControlsFiles().OrderBy(r => r).ToArray<object>();
            if (resourceFiles.Length > 0)
            {
                cbxSourcePath.Items.AddRange(resourceFiles);
                cbxSourcePath.SelectedIndex = 1;
                cbxDestinationPath.Items.AddRange(resourceFiles);
                cbxDestinationPath.SelectedIndex = 8;
            }

            rbtInsert.Checked = true;
        }

        private void btnCrawl_Click(object sender, EventArgs e)
        {
            lbxTranslations.Items.Clear();

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
            var sourceLanguages = GetLanguages().ToList();
            var resourceKeys = lbxTranslations.Items.Cast<string>().ToList();

            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            var databaseHandler = new DatabaseHandler(connectionString);
            var translationHandler = new TranslationHandler(sourceLanguages, resourceKeys, _folderHandler, databaseHandler);
            lbxInsertedTranslations.Items.Clear();
            if (rbtInsert.Checked)
            {
                foreach(var insertedTranslation in translationHandler.InsertTranslations(cbxSourcePath.SelectedItem.ToString(), cbxDestinationPath.SelectedItem.ToString()))
                {
                    lbxInsertedTranslations.ForeColor = System.Drawing.Color.MediumVioletRed;
                    lbxInsertedTranslations.Items.Add(insertedTranslation);
                }
            }
            else
            {
                // TODO: Not implemented. 1. Destination own translations are removed on update. 2. It seems it's not possible to find which translation to update sinse translation extension is missing in resourceKeys (e.g. .Text).
                //foreach (var updatedTranslation in translationHandler.UpdateTranslations(cbxSourcePath.SelectedItem.ToString(), cbxDestinationPath.SelectedItem.ToString()))
                //{
                //    lbxInsertedTranslations.ForeColor = System.Drawing.Color.BlueViolet;
                //    lbxInsertedTranslations.Items.Add(updatedTranslation);
                //}
            }
        }

        private IEnumerable<string> GetLanguages()
        {
            var selectedLanguage = cbxLanguages.SelectedItem.ToString();
            if (selectedLanguage == _allLanguages)
            {
                var sourceRelativeFilePath = cbxSourcePath.SelectedItem.ToString();
                foreach (var sourceLanguage in _folderHandler.GetAllSourceLanguages(sourceRelativeFilePath))
                {
                    yield return sourceLanguage;
                }
            }
            else
            {
                yield return selectedLanguage;
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
