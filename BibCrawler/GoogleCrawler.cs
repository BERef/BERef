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
    public class GoogleCrawler : ICrawler
    {
        #region Const Field
        private const string _googleSchoolar = "https://scholar.google.com";
        #endregion

        #region Private Field
        private List<BriefEntry> _briefEntryList;
        #endregion

        #region Constructor
        public GoogleCrawler()
        {
            _briefEntryList = new List<BriefEntry>();
        }
        #endregion

        #region Public Method
        public void Search(string keyword)
        {
            string GoogleSearchURL = _googleSchoolar + "/scholar?q=" + keyword;
            HtmlWeb htmlweb = new HtmlWeb();
            HtmlDocument htmldoc = htmlweb.Load(GoogleSearchURL);

            // Get all nodes
            var nodes = htmldoc.DocumentNode.SelectNodes("//div[@class='gs_ri']");

            foreach (var node in nodes)
            {
                // Get cite html in current node.
                var cite = node.SelectSingleNode(".//a[@onclick]");

                // If there is no cite in current node, continue.
                if (cite == null)
                {
                    continue;
                }
                BriefEntry briefEntry = new BriefEntry();

                // Get title.
                var title = node.SelectSingleNode(".//h3[@class='gs_rt']");
                if(title != null)
                {
                    foreach(var t in title.ChildNodes)
                    {
                        if(t.Name != "span")
                        {
                            briefEntry.Title += t.InnerText;
                        }
                    }
                }

                // Get profile, it includes authors, year, publish.
                briefEntry.Profile = node.SelectSingleNode(".//div[@class='gs_a']")?.InnerText;

                // Get abstract.
                briefEntry.Abstract = node.SelectSingleNode(".//div[@class='gs_rs']")?.InnerText;

                // Get cite url.
                var citeId = cite.Attributes["onclick"].Value.Split(',')[1];
                briefEntry.CiteUrl = _googleSchoolar + "/scholar?q=" + "info:" + citeId.Substring(1, citeId.Length - 2) + ":scholar.google.com/&output=cite&scirp=0&hl=zh-CN";

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
            HtmlWeb citeWeb = new HtmlWeb();
            var citeUrl = _googleSchoolar + WebUtility.HtmlDecode(citeWeb.Load(briefEntry.CiteUrl).DocumentNode.SelectSingleNode("//a[@class='gs_citi']")?.Attributes["href"].Value);

            WebRequest webRequest = WebRequest.Create(citeUrl);
            WebResponse webResponse = webRequest.GetResponse();

            string bibtex = null;
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream(), Encoding.Default))
            {
                bibtex = reader.ReadToEnd();
            }
            return bibtex;
        }
        #endregion
    }
}
