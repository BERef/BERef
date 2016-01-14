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
            var googleSearchProvider = new GoogleSearchProvider();
            var result = googleSearchProvider.GetResult("hadoop");
        }
    }
}
