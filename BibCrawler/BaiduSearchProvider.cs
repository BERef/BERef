using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace BibCrawler
{
    public sealed class BaiduSearchProvider : RefSearchProvider<HtmlNode>
    {
        #region Const Field
        private static readonly string _baiduScholarURL = "http://xueshu.baidu.com";
        private static readonly string _baiduCiteURL = "http://xueshu.baidu.com/u/citation?url=";

        private static readonly string _entryPath = "//div[@tpl='se_st_sc_default']";
        private static readonly string _citePath = ".//a[@data-click=\"{\'button_tp\':\'cite\'}\"]";
        private static readonly string _titlePath = ".//a[@data-click=\"{\'button_tp\':\'title\'}\"]";
        private static readonly string _authorsPath = ".//a[@data-click=\"{\'button_tp\':\'author\'}\"]";
        private static readonly string _publishPath = ".//a[@data-click=\"{\'button_tp\':\'publish\'}\"]";
        private static readonly string _yearPath = ".//span[@data-year]";
        private static readonly string _abstractPath = ".//div[@class='c_abstract']";

        private static readonly string _citeLinkAttrName = "data-link";
        private static readonly string _citeSignAttrName = "data-sign";
        #endregion

        #region Private Field
        private HtmlWeb _htmlWeb = new HtmlWeb();
        private HtmlDocument _htmlDoc;
        #endregion

        #region Constructor
        public BaiduSearchProvider()
        {
        }
        #endregion

        #region Private Method
        private void GetSearchPage(string keyword)
        {
            _htmlDoc = _htmlWeb.Load($"{_baiduScholarURL}/s?wd={keyword}");
        }

        private string ParseCiteUrl(HtmlNode item)
        {
            // Get cite html in current node.
            var cite = item.SelectSingleNode(_citePath);

            // If there is no cite in current node, continue.
            if (cite == null)
                return null;

            // Get cite url's parameter.
            var citeLink = cite.Attributes[_citeLinkAttrName].Value;
            var citeSign = cite.Attributes[_citeSignAttrName].Value;
            return $"{_baiduCiteURL}{WebUtility.UrlEncode(citeLink)}&sign={citeSign}&t=bib";
        }
        #endregion

        #region Public Override Method
        /// <summary>
        /// Get a ref entry list from Baidu schoolar search engine.
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

        protected override string ParseProfile(HtmlNode item)
        {
            // Get profile, it includes authors, year, publish.
            var authors = item.SelectNodes(_authorsPath);
            var authorList = new StringBuilder();
            if (authors != null)
            {
                foreach (var author in authors)
                {
                    authorList.Append(author.InnerText);
                    authorList.Append(_separator);
                }
                authorList.Remove(authorList.Length - _separator.Length, _separator.Length);
            }
            else authorList.Append(_none);
            var publish = item.SelectSingleNode(_publishPath)?.InnerText ?? _none;
            var year = item.SelectSingleNode(_yearPath)?.InnerText ?? _none;

            return $"{authorList.ToString()} - {publish} - {year}";
        }

        protected override string ParseAbstract(HtmlNode item)
        {
            return item.SelectSingleNode(_abstractPath)?.InnerText;
        }

        protected override string ParseTitle(HtmlNode item)
        {
            return item.SelectSingleNode(_titlePath)?.InnerText;
        }

        protected override string Source(HtmlNode item)
        {
            var partUrl = item.SelectSingleNode(_titlePath).GetAttributeValue("href", string.Empty);
            if (partUrl == "")
                return partUrl;
            else
                return $"{_baiduScholarURL}{item.SelectSingleNode(_titlePath).GetAttributeValue("href", "")}";
        }
        #endregion
    }
}
