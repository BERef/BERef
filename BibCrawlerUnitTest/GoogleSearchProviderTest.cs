using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibCrawler;

namespace BibCrawlerUnitTest
{
    [TestClass]
    public class GoogleSearchProviderTest
    {
        [TestMethod]
        public void TestGetResult()
        {
            GoogleSearchProvider googleCrawler = new GoogleSearchProvider("Hadoop");
            var result = googleCrawler.GetResult();
        }

        [TestMethod]
        public void TestGetBibTex()
        {
            GoogleSearchProvider googleCrawler = new GoogleSearchProvider("Hadoop");
            var result = googleCrawler.GetResult();
            var bibTex = googleCrawler.GetBibTex(result[0]);
        }
    }
}
