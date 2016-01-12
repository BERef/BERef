using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BibCrawlerUnitTest
{
    [TestClass]
    public class BaiduCrawlerTest
    {
        [TestMethod]
        public void TestSearch()
        {
            BibCrawler.BaiduCrawler baiduCrawler = new BibCrawler.BaiduCrawler();
            baiduCrawler.Search("搜索");
        }

        [TestMethod]
        public void TestGetBibTex()
        {
            BibCrawler.BaiduCrawler baiduCrawler = new BibCrawler.BaiduCrawler();
            baiduCrawler.Search("搜索");
            var list = baiduCrawler.GetList();
            var bibTex = baiduCrawler.GetBibTex(list[0]);
        }
    }
}
