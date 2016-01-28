using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScholarProviderInterface;

namespace BaiduScholarProvider
{
    public class SourceParser:IParser<HtmlNode>
    {
        public string Parse(HtmlNode item)
        {
            var partUrl = item.SelectSingleNode(RuleSet.TitlePath).GetAttributeValue("href", string.Empty);
            if (partUrl == string.Empty)
                return partUrl;
            else
                return $"{RuleSet.BaiduScholarUrl}{item.SelectSingleNode(RuleSet.TitlePath).GetAttributeValue("href", "")}";
        }
    }
}
