using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibCrawler;

namespace BibCrawlerUnitTest
{
    [TestClass]
    public class GoogleCrawlerTest
    {
        [TestMethod]
        public void TestSearch()
        {
            GoogleCrawler googleCrawler = new GoogleCrawler();
            googleCrawler.Search("hadoop");
        }

        [TestMethod]
        public void TestGetBibTex()
        {
            GoogleCrawler googleCrawler = new GoogleCrawler();
            googleCrawler.Search("搜索");
            var list = googleCrawler.GetList();
            var bibTex = googleCrawler.GetBibTex(list[0]);
        }
    }
}
