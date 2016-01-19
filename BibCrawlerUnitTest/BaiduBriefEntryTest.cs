using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibCrawler;

namespace BibCrawlerUnitTest
{
    [TestClass]
    public class BaiduBriefEntryTest
    {
        [TestMethod]
        public void TestGetBibTex()
        {
            var entry = new BaiduBriefEntry();
            // keyword is "hadoop"
            entry.CiteUrl = "http://xueshu.baidu.com/u/citation?url=http%3A%2F%2Fdl.acm.org%2Fcitation.cfm%3Fid%3D2285539&sign=190db10476f7878b15624a9c076ef027&t=bib";
            var bib = entry.BibTeX;
        }
    }
}
