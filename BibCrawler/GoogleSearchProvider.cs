using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.IO;

namespace BibCrawler
{
    public class GoogleSearchProvider : RefSearchProvider
    {
        #region Const Field
        private static readonly string _googleScholarURL       = "https://scholar.google.com";
        private static readonly string _googleScholarSearchURL = "https://scholar.google.com/scholar?q=";
        private static readonly string _googleCiteURL          = "https://scholar.google.com/scholar.bib?q=info:";
        private static readonly string _googleCiteURLSuffix    = ":scholar.google.com/&output=cite&scirp=0&hl=zh-CN";

        private static readonly string _entryPath    = "//div[@class='gs_ri']";
        private static readonly string _citePath     = ".//a[@onclick]";
        private static readonly string _titlePath    = ".//h3[@class='gs_rt']";
        private static readonly string _profilePath  = ".//div[@class='gs_a']";
        private static readonly string _abstractPath = ".//div[@class='gs_rs']";

        private static readonly string _citeIdAttrName = "onclick";
        #endregion

        #region Private Field
        private List<BriefEntry> _briefEntryList = new List<BriefEntry>();
        #endregion

        #region Constructor
        public GoogleSearchProvider(string keyword)
        {
            Search(keyword);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Get a ref entry list from Google schoolar search engine.
        /// </summary>
        /// <returns></returns>
        public override IList<BriefEntry> GetResult()
        {
            return _briefEntryList;
        }
        #endregion

        #region Private Method
        private void Search(string keyword)
        {
            var htmlweb = new HtmlWeb();
            var htmldoc = htmlweb.Load($"{_googleScholarSearchURL}{keyword}");

            // Get all nodes
            var nodes = htmldoc.DocumentNode.SelectNodes(_entryPath);

            foreach (var node in nodes)
            {
                // Get cite html in current node.
                var cite = node.SelectSingleNode(_citePath);

                // If there is no cite in current node, continue.
                if (cite == null) continue;

                // Get title.
                var title = node.SelectSingleNode(_titlePath);
                var titleBuilder = new StringBuilder();
                foreach (var t in title.ChildNodes)
                {
                    if (t.Name != "span")
                        titleBuilder.Append(t.InnerText);
                }

                // Get cite url's parameter.
                var citeId = cite.Attributes[_citeIdAttrName].Value.Split(',')[1];

                // Build entry
                var briefEntry      = new GoogleBriefEntry();
                briefEntry.Title    = titleBuilder.ToString();
                briefEntry.Profile  = node.SelectSingleNode(_profilePath)?.InnerText;
                briefEntry.Abstract = node.SelectSingleNode(_abstractPath)?.InnerText;
                briefEntry.CiteUrl  = $"{_googleCiteURL}{citeId.Substring(1, citeId.Length - 2)}{_googleCiteURLSuffix}";
                _briefEntryList.Add(briefEntry);
            }
        }
        #endregion
    }
}
