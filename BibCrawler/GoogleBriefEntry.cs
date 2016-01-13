using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BibCrawler
{
    class GoogleBriefEntry : BriefEntry
    {
        private string _googleScholarURL = "https://scholar.google.com";
        public override string GetBibTex()
        {
            var citeWeb = new HtmlWeb();
            // Get Bibtex url from cite url list.
            var citeUrl = $"{_googleScholarURL}{WebUtility.HtmlDecode(citeWeb.Load(CiteUrl).DocumentNode.SelectSingleNode("//a[@class='gs_citi']")?.Attributes["href"].Value)}";

            var webRequest = WebRequest.Create(citeUrl);
            var webResponse = webRequest.GetResponse();

            string bibtex = null;
            using (var reader = new StreamReader(webResponse.GetResponseStream(), Encoding.Default))
            {
                bibtex = reader.ReadToEnd();
            }
            return bibtex;
        }
    }
}
