using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BibCrawler
{
    class BaiduBriefEntry : BriefEntry
    {
        public override string GetBibTex()
        {
            var webRequest = WebRequest.Create(CiteUrl);
            var webResponse = webRequest.GetResponse();

            string bibtex = null;
            using (var reader = new StreamReader(webResponse.GetResponseStream()))
            {
                bibtex = reader.ReadToEnd();
            }
            return bibtex;
        }
    }
}
