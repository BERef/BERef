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
    public sealed class GoogleBriefEntry : BriefEntry
    {

        #region Private Field
        private string _citeUrl;
        private string _googleScholarURL = "https://scholar.google.com";
        #endregion

        #region Public Field
        public string CiteUrl
        {
            set
            {
                if (value != null)
                    _citeUrl = value;
                else
                {
                    throw new NullReferenceException("CiteUrl is required.");
                }
            }
        }
        #endregion

        #region Implement Abstract Method
        /// <summary>
        /// Get BibTeX from Google Scholar.
        /// </summary>
        /// <returns></returns>
        protected override string GetBibTeX()
        {
            var citeWeb = new HtmlWeb();
            // Get Bibtex url from cite url list.
            var citeUrl = $"{_googleScholarURL}{WebUtility.HtmlDecode(citeWeb.Load(_citeUrl).DocumentNode.SelectSingleNode("//a[@class='gs_citi']")?.Attributes["href"].Value)}";

            var webRequest = WebRequest.Create(citeUrl);
            var webResponse = webRequest.GetResponse();

            string bibtex = null;
            using (var reader = new StreamReader(webResponse.GetResponseStream(), Encoding.Default))
            {
                bibtex = reader.ReadToEnd();
            }
            return bibtex;
        }
        #endregion
    }
}
