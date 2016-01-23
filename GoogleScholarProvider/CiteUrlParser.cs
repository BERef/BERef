using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScholarProviderInterface;
using HtmlAgilityPack;

namespace GoogleScholarProvider
{
    public class CiteUrlParser : IParser<HtmlNode>
    {
        #region Implement 'IParser'
        public string Parse(HtmlNode item)
        {
            // Get cite html in current node.
            var cite = item.SelectSingleNode(RuleSet.CitePath);

            // If there is no cite in current node, continue.
            if (cite == null)
                return null;

            // Get cite url's parameter.
            var citeId = cite.Attributes[RuleSet.CiteIdAttrName].Value.Split(',')[1];
            return $"{RuleSet.GoogleCiteURL}{citeId.Substring(1, citeId.Length - 2)}{RuleSet.GoogleCiteURLSuffix}";
        }
        #endregion
    }
}