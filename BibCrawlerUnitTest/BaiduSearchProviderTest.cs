using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BibCrawlerUnitTest
{
    [TestClass]
    public class BaiduSearchProviderTest
    {
        [TestMethod]
        public void TestGetResult()
        {
            BibCrawler.BaiduSearchProvider baiduCrawler = new BibCrawler.BaiduSearchProvider("Search");
            baiduCrawler.GetResult();
        }

        [TestMethod]
        public void TestGetBibTex()
        {
            //BibCrawler.BaiduCrawler baiduCrawler = new BibCrawler.BaiduCrawler();
            //baiduCrawler.Search("搜索");
            //var list = baiduCrawler.GetResult();
            //var bibTex = baiduCrawler.GetBibTex(list[0]);
        }
    }
}
