using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace TranslationCrawler
{
    public class TranslationHandler
    {
        private readonly List<string> _languages;
        private readonly List<string> _resourceKeys;
        private readonly IFolderHandler _folderHandler;

        public TranslationHandler(List<string> languages, List<string> resourceKeys, IFolderHandler folderHandler)
        {
            _languages = languages;
            _resourceKeys = resourceKeys;
            _folderHandler = folderHandler;
        }

        public void InsertTranslations(string sourceRelativePath, string destinationRelativePath)
        {
            foreach(var language in _languages)
            {
                var translations = GetTranslations(sourceRelativePath, language);
                // TODO: Check if resource already exists.

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

        public void UpdateTranslations(string sourceRelativePath, string destinationRelativePath)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, string> GetTranslations(string sourceRelativePath, string language)
        {
            var translations = new Dictionary<string, string>();

            var resourceFilePath = _folderHandler.GetResourceFilePath(sourceRelativePath, language);
            using (ResXResourceSet resxSet = new ResXResourceSet(resourceFilePath))
            {
                foreach(DictionaryEntry resource in resxSet)
                {
                    translations.Add(resource.Key.ToString(), resource.Value.ToString());
                }
            }

            return translations;
        } 

        public static void UpdateResourceFile(Hashtable data, String path)
        {
            Hashtable resourceEntries = new Hashtable();

            //Get existing resources
            ResXResourceReader reader = new ResXResourceReader(path);
            ResXResourceWriter resourceWriter = new ResXResourceWriter(path);

            if (reader != null)
            {
                IDictionaryEnumerator id = reader.GetEnumerator();
                foreach (DictionaryEntry d in reader)
                {
                    //Read from file:
                    string val = "";
                    if (d.Value == null)
                        resourceEntries.Add(d.Key.ToString(), "");
                    else
                    {
                        resourceEntries.Add(d.Key.ToString(), d.Value.ToString());
                        val = d.Value.ToString();
                    }

                    //Write (with read to keep xml file order)
                    resourceWriter.AddResource(d.Key.ToString(), val);

                }
                reader.Close();
            }

            //Add new data (at the end of the file):
            Hashtable newRes = new Hashtable();
            foreach (String key in data.Keys)
            {
                if (!resourceEntries.ContainsKey(key))
                {

                    String value = data[key].ToString();
                    if (value == null) value = "";

                    resourceWriter.AddResource(key, value);
                }
            }

            //Write to file
            resourceWriter.Generate();
            resourceWriter.Close();
        }
    }
}
