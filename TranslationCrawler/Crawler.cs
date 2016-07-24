using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TranslationCrawler
{
    public class Crawler
    {
        private readonly string _content;

        public Crawler(string content)
        {
            _content = content;
        }

        public IEnumerable<string> FindMetaResourceKeys()
        {
            string patternMetaResourceKeys = "meta:resourcekey=\"(.*?)\"";
            return FindResourceKeys(patternMetaResourceKeys);
        }

        public IEnumerable<string> FindResourceKeys(string pattern)
        {
            foreach (Match m in Regex.Matches(_content, pattern))
            {
                if (m.Groups.Count == 2)
                {
                    yield return m.Groups[1].Value;
                }
            }
        }

        public IEnumerable<string> FindMaskLocalResourceKeys()
        {
            string patternMaskLocalResourceKeys = "GetMaskedLocalResource\\(\"(.*?)\"";
            return FindResourceKeys(patternMaskLocalResourceKeys);
        }

        public IEnumerable<string> FindAllResourceKeys()
        {
            foreach (var resource in FindMetaResourceKeys())
            {
                yield return resource;
            }
            foreach (var resource in FindMaskLocalResourceKeys())
            {
                yield return resource;
            }
        }
    }
}
