using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScholarProviderInterface;

namespace BaiduScholarProvider
{
    public class CiteUrlParser : IParser<HtmlNode>
    {
        public string Parse(HtmlNode item)
        {
            // Get cite html in current node.
            var cite = item.SelectSingleNode(RuleSet.CitePath);

            // If there is no cite in current node, return.
            if (cite == null)
                return null;

            // Get cite url's parameter.
            var citeLink = cite.Attributes[RuleSet.CiteLinkAttrName].Value;
            var citeSign = cite.Attributes[RuleSet.CiteSignAttrName].Value;
            return $"{RuleSet.BaiduCiteUrl}{WebUtility.UrlEncode(citeLink)}&sign={citeSign}&t=bib";
        }
    }
}
