using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScholarProviderInterface;
using System.Net;

namespace GoogleScholarProvider
{
    public class SourceParser : IParser<HtmlNode>
    {
        #region Implement 'IParser'
        public string Parse(HtmlNode item)
        {
            var link = item.SelectSingleNode(RuleSet.SourcePath);
            if (link == null)
                return string.Empty;
            var linkUrl = link.GetAttributeValue("href", string.Empty);
            return linkUrl == string.Empty ? string.Empty : WebUtility.HtmlDecode(linkUrl);
        }
        #endregion
    }
}
