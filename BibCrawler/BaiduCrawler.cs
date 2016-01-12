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
    public class BaiduCrawler : ICrawler
    {
        #region Const Field
        private const string _baiduSchoolar = "http://xueshu.baidu.com/s?wd=";
        private const string _baiduCiteURL = "http://xueshu.baidu.com/u/citation";
        #endregion

        #region Private Field
        private List<BriefEntry> _briefEntryList;
        #endregion

        #region Constructor
        public BaiduCrawler()
        {
            _briefEntryList = new List<BriefEntry>();
        }
        #endregion

        #region Public Method
        public void Search(string keyword)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDoc = htmlWeb.Load(_baiduSchoolar + keyword);

            // Get all result nodes
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@tpl='se_st_sc_default']");

            foreach (var node in nodes)
            {
                // Get cite html in current node.
                var cite = node.SelectSingleNode(".//a[@data-click=\"{\'button_tp\':\'cite\'}\"]");

                // If there is no cite in current node, continue.
                if (cite == null)
                {
                    continue;
                }

                BriefEntry briefEntry = new BriefEntry();

                // Get title.
                briefEntry.Title = node.SelectSingleNode(".//a[@data-click=\"{\'button_tp\':\'title\'}\"]")?.InnerText;

                // Get profile, it includes authors, year, publish.
                var authors = node.SelectNodes(".//a[@data-click=\"{\'button_tp\':\'author\'}\"]");
                StringBuilder authorList = new StringBuilder();
                if (authors != null)
                {
                    foreach (var author in authors)
                    {
                        authorList.Append(author.InnerText);
                        authorList.Append(", ");
                    }
                    authorList.Remove(authorList.Length - 2, 2);
                }
                else
                {
                    authorList.Append("None");
                }

                var publish = node.SelectSingleNode(".//a[@data-click=\"{\'button_tp\':\'publish\'}\"]")?.InnerText;
                publish = publish == null ? "None" : publish;

                var year = node.SelectSingleNode(".//span[@data-year]")?.InnerText;
                year = year == null ? "None" : year;

                briefEntry.Profile = $"{authorList.ToString()} - {publish} - {year}";

                // Get abstract.
                briefEntry.Abstract = node.SelectSingleNode(".//div[@class='c_abstract']")?.InnerText;

                // Get cite url.
                var link = cite.Attributes["data-link"].Value;
                var sign = cite.Attributes["data-sign"].Value;
                briefEntry.CiteUrl = _baiduCiteURL + "?url=" + System.Net.WebUtility.UrlEncode(link) + "&sign=" + sign + "&t=bib";

                // Add current briefEntry to list.
                _briefEntryList.Add(briefEntry);
            }
        }

        public IList<BriefEntry> GetList()
        {
            return _briefEntryList;
        }

        public string GetBibTex(BriefEntry briefEntry)
        {
            WebRequest webRequest = WebRequest.Create(briefEntry.CiteUrl);
            WebResponse webResponse = webRequest.GetResponse();

            string bibtex = null;
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                bibtex = reader.ReadToEnd();
            }
            return bibtex;
        }
        #endregion
    }
}
