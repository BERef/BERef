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
    public sealed class BaiduSearchProvider : RefSearchProvider
    {
        #region Const Field
        private static readonly string _baiduScholarURL = "http://xueshu.baidu.com/s?wd=";
        private static readonly string _baiduCiteURL    = "http://xueshu.baidu.com/u/citation?url=";

        private static readonly string _entryPath    = "//div[@tpl='se_st_sc_default']";
        private static readonly string _citePath     = ".//a[@data-click=\"{\'button_tp\':\'cite\'}\"]";
        private static readonly string _titlePath    = ".//a[@data-click=\"{\'button_tp\':\'title\'}\"]";
        private static readonly string _authorsPath  = ".//a[@data-click=\"{\'button_tp\':\'author\'}\"]";
        private static readonly string _publishPath  = ".//a[@data-click=\"{\'button_tp\':\'publish\'}\"]";
        private static readonly string _yearPath     = ".//span[@data-year]";
        private static readonly string _abstractPath = ".//div[@class='c_abstract']";

        private static readonly string _citeLinkAttrName = "data-link";
        private static readonly string _citeSignAttrName = "data-sign";
        #endregion

        #region Private Field
        private List<BriefEntry> _briefEntryList = new List<BriefEntry>();
        #endregion

        #region Constructor
        public BaiduSearchProvider(string keyword)
        {
            Search(keyword);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Get a ref entry list from Baidu schoolar search engine.
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
            var htmlWeb = new HtmlWeb();
            var htmlDoc = htmlWeb.Load($"{_baiduScholarURL}{keyword}");

            // Get all result nodes
            var nodes = htmlDoc.DocumentNode.SelectNodes(_entryPath);

            foreach (var node in nodes)
            {
                // Get cite html in current node.
                var cite = node.SelectSingleNode(_citePath);

                // If there is no cite in current node, continue.
                if (cite == null) continue;

                // Get cite url's parameter.
                var citeLink = cite.Attributes[_citeLinkAttrName].Value;
                var citeSign = cite.Attributes[_citeSignAttrName].Value;

                // Get profile, it includes authors, year, publish.
                var authors = node.SelectNodes(_authorsPath);
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
                var publish = node.SelectSingleNode(_publishPath)?.InnerText ?? _none;
                var year = node.SelectSingleNode(_yearPath)?.InnerText ?? _none;

                // Build entry
                var briefEntry      = new BaiduBriefEntry();
                briefEntry.CiteUrl  = $"{_baiduCiteURL}{WebUtility.UrlEncode(citeLink)}&sign={citeSign}&t=bib";
                briefEntry.Profile  = $"{authorList.ToString()} - {publish} - {year}";
                briefEntry.Title    = node.SelectSingleNode(_titlePath)?.InnerText;
                briefEntry.Abstract = node.SelectSingleNode(_abstractPath)?.InnerText;
                _briefEntryList.Add(briefEntry);
            }
        }
        #endregion
    }
}
