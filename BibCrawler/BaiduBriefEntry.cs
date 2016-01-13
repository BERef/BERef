using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BibCrawler
{
    public sealed class BaiduBriefEntry : BriefEntry
    {

        #region Private Field
        private string _citeUrl;
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
        /// Get BibTeX from Baidu Scholar.
        /// </summary>
        /// <returns></returns>
        protected override string GetBibTeX()
        {
            var webRequest = WebRequest.Create(_citeUrl);
            var webResponse = webRequest.GetResponse();

            string bibtex = null;
            using (var reader = new StreamReader(webResponse.GetResponseStream()))
            {
                bibtex = reader.ReadToEnd();
            }
            return bibtex;
        }
        #endregion
    }
}
