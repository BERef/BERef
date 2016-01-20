using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibCrawler;
using HtmlAgilityPack;

namespace BibCrawlerUnitTest
{
    [TestClass]
    public class GoogleSearchProviderTest
    {
        [TestMethod]
        public void TestGetResult()
        {
            var googleSearchProvider = new GoogleSearchProvider();

            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(@"D:\Projects\BERef\BibCrawlerUnitTest\HadoopGoogleScholar.html");
            try
            {

            }
            catch
            {

            }
            var result = googleSearchProvider.GetResult("hadoop");
        }
    }
}
