using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;
using GoogleScholarProvider;
using System.Collections.Generic;

namespace GoogleScholarProviderUnitTest
{
    [TestClass]
    public class SpliterTest
    {
        [TestMethod]
        public void TestSpliter()
        {
            var htmlDoc = new HtmlDocument();
            // Read Test File
            htmlDoc.Load(@"TestData/SearchResultPage.data");

            var spliter = new Spliter();
            var result = spliter.Split(htmlDoc);
            int count = 0;
            foreach (var node in result)
                count++;

            Assert.AreEqual(10, count);
        }
    }
}
