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

        public TranslationHandler(List<string> languages, List<string> resourceKeys)
        {
            _languages = languages;
            _resourceKeys = resourceKeys;
        }

        public void InsertTranslations(string sourceRelativePath, string destinationRelativePath)
        {
            throw new NotImplementedException();
        }

        public void UpdateTranslations(string sourceRelativePath, string destinationRelativePath)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, string> GetTranslations(string sourceRelativePath)
        {
            var translations = new Dictionary<string, string>();
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
