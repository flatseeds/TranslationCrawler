using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;

namespace TranslationCrawler
{
    public class TranslationHandler
    {
        private readonly List<string> _languages;
        private readonly List<string> _resourceKeys;
        private readonly IFolderHandler _folderHandler;
        private readonly DatabaseHandler _databaseHandler;

        public TranslationHandler(List<string> languages, List<string> resourceKeys, IFolderHandler folderHandler, DatabaseHandler databaseHandler)
        {
            _languages = languages;
            _resourceKeys = resourceKeys;
            _folderHandler = folderHandler;
            _databaseHandler = databaseHandler;
        }

        public void InsertTranslations(string sourceRelativePath, string destinationRelativePath)
        {
            foreach (var language in _languages)
            {
                var translations = GetTranslationsForInsert(sourceRelativePath, destinationRelativePath, language);

                var destinationResourceFilePath = _folderHandler.GetResourceFilePath(destinationRelativePath, language);
                using (ResXResourceWriter resx = new ResXResourceWriter(destinationResourceFilePath))
                {
                    foreach (var resourceKey in _resourceKeys)
                    {
                        foreach (var resourcesToInsert in translations.Where(r => r.Key.StartsWith(resourceKey)))
                        {
                            _databaseHandler.SaveTranslationMovingHistory(sourceRelativePath, destinationRelativePath, resourceKey, language);
                            resx.AddResource(resourcesToInsert.Key, resourcesToInsert.Value);
                        }
                    }
                    resx.Generate();
                }
            }
        }

        public void UpdateTranslations(string sourceRelativePath, string destinationRelativePath)
        {
            foreach (var language in _languages)
            {
                var translations = GetTranslationsForUpdate(sourceRelativePath, destinationRelativePath, language);

                var destinationResourceFilePath = _folderHandler.GetResourceFilePath(destinationRelativePath, language);
                using (ResXResourceWriter resx = new ResXResourceWriter(destinationResourceFilePath))
                {
                    foreach (var resourceKey in _resourceKeys)
                    {
                        foreach (var resourcesToInsert in translations.Where(r => r.Key.StartsWith(resourceKey)))
                        {
                            resx.AddResource(resourcesToInsert.Key, resourcesToInsert.Value);
                        }
                    }
                    resx.Generate();
                }
            }
        }

        private IEnumerable<KeyValuePair<string, string>> GetTranslationsForInsert(string sourceRelativePath, string destinationRelativePath, string language)
        {
            var translations = GetTranslations(sourceRelativePath, language);
            var existingTranslations = GetTranslations(destinationRelativePath, language);
            var onlyNewTranslations = translations.Except(existingTranslations);
            return onlyNewTranslations;
        }

        private IEnumerable<KeyValuePair<string, string>> GetTranslationsForUpdate(string sourceRelativePath, string destinationRelativePath, string language)
        {
            var existingTranslations = GetTranslations(destinationRelativePath, language);
            return existingTranslations;
        }

        private Dictionary<string, string> GetTranslations(string sourceRelativePath, string language)
        {
            var translations = new Dictionary<string, string>();

            var resourceFilePath = _folderHandler.GetResourceFilePath(sourceRelativePath, language);
            if (!File.Exists(resourceFilePath))
            {
                using (var rw = new ResXResourceWriter(resourceFilePath))
                {
                    rw.Generate();
                }
            }

            using (ResXResourceSet resxSet = new ResXResourceSet(resourceFilePath))
            {
                foreach (DictionaryEntry resource in resxSet)
                {
                    translations.Add(resource.Key.ToString(), resource.Value.ToString());
                }
            }

            return translations;
        }
    }
}
