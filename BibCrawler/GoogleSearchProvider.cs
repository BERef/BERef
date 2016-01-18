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
    public class GoogleSearchProvider : RefSearchProvider<HtmlNode>
    {
        #region Const Field
        private static readonly string _googleScholarURL = "https://scholar.google.com";
        private static readonly string _googleScholarSearchURL = "https://scholar.google.com/scholar?q=";
        private static readonly string _googleCiteURL = "https://scholar.google.com/scholar.bib?q=info:";
        private static readonly string _googleCiteURLSuffix = ":scholar.google.com/&output=cite&scirp=0&hl=zh-CN";

        private static readonly string _entryPath = "//div[@class='gs_ri']";
        private static readonly string _citePath = ".//a[@onclick]";
        private static readonly string _titlePath = ".//h3[@class='gs_rt']";
        private static readonly string _profilePath = ".//div[@class='gs_a']";
        private static readonly string _abstractPath = ".//div[@class='gs_rs']";

        private static readonly string _citeIdAttrName = "onclick";
        #endregion

        #region Private Field
        private HtmlWeb _htmlWeb = new HtmlWeb();
        private HtmlDocument _htmlDoc;
        #endregion

        #region Constructor
        public GoogleSearchProvider()
        {
        }
        #endregion

        #region Private Method
        private void GetSearchPage(string keyword)
        {
            _htmlDoc = _htmlWeb.Load($"{_googleScholarSearchURL}{keyword}");
        }

        private string ParseCiteUrl(HtmlNode node)
        {
            // Get cite html in current node.
            var cite = node.SelectSingleNode(_citePath);

            // If there is no cite in current node, continue.
            if (cite == null)
                return null;

            // Get cite url's parameter.
            var citeId = cite.Attributes[_citeIdAttrName].Value.Split(',')[1];
            return $"{_googleCiteURL}{citeId.Substring(1, citeId.Length - 2)}{_googleCiteURLSuffix}";
        }

        #endregion

        #region Public Override Method
        /// <summary>
        /// Get a ref entry list from Google schoolar search engine.
        /// </summary>
        /// <returns></returns>
        public override IList<BriefEntry> GetResult(string keyword)
        {
            GetSearchPage(keyword);
            return Parse();
        }
        #endregion

        #region Protected Override Method
        protected override IEnumerable<Tuple<HtmlNode, BriefEntry>> ParsePairs()
        {
            var nodes = _htmlDoc.DocumentNode.SelectNodes(_entryPath);

            foreach (var node in nodes)
            {
                var citeUrl = ParseCiteUrl(node);
                if (citeUrl == null)
                    continue;

                // Build entry
                var entry = new BaiduBriefEntry();
                entry.CiteUrl = citeUrl;
                yield return new Tuple<HtmlNode, BriefEntry>(node, entry);
            }
        }

        protected override string ParseTitle(HtmlNode item)
        {
            var title = item.SelectSingleNode(_titlePath);
            var titleBuilder = new StringBuilder();
            foreach (var t in title.ChildNodes)
            {
                if (t.Name != "span")
                    titleBuilder.Append(t.InnerText);
            }
            return titleBuilder.ToString();
        }

        protected override string ParseProfile(HtmlNode item)
        {
            return item.SelectSingleNode(_profilePath)?.InnerText;
        }

        protected override string ParseAbstract(HtmlNode item)
        {
            return item.SelectSingleNode(_abstractPath)?.InnerText;
        }

        protected override string Source(HtmlNode item)
        {
            var link = item.SelectSingleNode(_titlePath)?.SelectSingleNode(".//a");
            if (link == null)
                return string.Empty;
            var linkUrl = link.GetAttributeValue("href", string.Empty);
            return linkUrl == string.Empty ? string.Empty : WebUtility.HtmlDecode(linkUrl);
        }
        #endregion
    }
}

