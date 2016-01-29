using System;
using System.Collections.Generic;

using ScholarProviderInterface;
using HtmlAgilityPack;
using System.Diagnostics;

namespace GoogleScholarProvider
{
    public class BriefBuilder : IBuilder<HtmlNode>
    {
        #region Private Field
        private Dictionary<string, IParser<HtmlNode>> _parsers =
            new Dictionary<string, IParser<HtmlNode>>
            {
                {"title"   , new TitleParser() },
                {"source"  , new SourceParser() },
                {"abstract", new AbstractParser() },
                {"profile" , new ProfileParser() },
                {"citeUrl" , new CiteUrlParser() }
            };
        #endregion

        #region Private Method
        private IParser<HtmlNode> GetParser(string type)
        {
            Debug.Assert(_parsers.ContainsKey(type));
            return _parsers[type];
        }
        #endregion

        #region Implement 'IBuilder'
        /// <summary>
        /// Using parsers parse HtmlNode and build GoogleBriefEntry.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public BriefEntry Build(HtmlNode item)
        {
            var citeUrl = GetParser("citeUrl").Parse(item);
            // CiteUrl is required
            if (citeUrl == null)
                return null;
            var title   = GetParser("title").Parse(item);
            var source  = GetParser("source").Parse(item);
            var abstrct = GetParser("abstract").Parse(item);
            var profile = GetParser("profile").Parse(item);
            return new GoogleBriefEntry(title, source, abstrct, profile, citeUrl);
        }
        #endregion
    }
}
