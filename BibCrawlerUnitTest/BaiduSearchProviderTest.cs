using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibCrawler;
using HtmlAgilityPack;

namespace BibCrawlerUnitTest
{
    [TestClass]
    public class BaiduSearchProviderTest
    {
        [TestMethod]
        public void TestGetResult()
        {
            var baiduSearchProvider = new BaiduSearchProvider();
            var result = baiduSearchProvider.GetResult("hadoop");
        }
    }
}
