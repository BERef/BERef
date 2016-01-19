using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibCrawler;
namespace BibCrawlerUnitTest
{
    [TestClass]
    public class GoogleBriefEntryTest
    {
        [TestMethod]
        public void TestGetBibTex()
        {
            var entry = new GoogleBriefEntry();
            // keyword is "hadoop"
            entry.CiteUrl = "https://scholar.google.com/scholar.bib?q=info:rLXN4dYUFrAJ:scholar.google.com/&output=cite&scirp=0&hl=zh-CN";
            var bib = entry.BibTeX;
        }
    }
}
