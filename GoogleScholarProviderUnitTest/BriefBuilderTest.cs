using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;
using GoogleScholarProvider;

namespace GoogleScholarProviderUnitTest
{
    [TestClass]
    public class BriefBuilderTest
    {
        [TestMethod]
        public void TestBuilder()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(@"TestData/SearchResultPage.data");
            var spliter = new Spliter();
            var iter = spliter.Split(htmlDoc).GetEnumerator();
            iter.MoveNext();
            var node = iter.Current;

            var builder = new BriefBuilder();
            var brief = builder.Build(node);

            Assert.AreEqual("Understanding big data: Analytics for enterprise class hadoop and streaming data", brief.Title);
            Assert.AreEqual("http://dl.acm.org/citation.cfm?id=2132803", brief.Source);
            Assert.AreEqual("Abstract Big Data represents a new era in data exploration and utilization, and IBM is uniquely positioned to help clients navigate this transformation. This book reveals how IBM is leveraging open source Big Data technology, infused with IBM technologies, to deliver a  ...", brief.Abstract);
            Assert.AreEqual("P Zikopoulos, C Eaton - 2011 - dl.acm.org", brief.Profile);
        }
    }
}
