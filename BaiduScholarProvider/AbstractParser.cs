using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScholarProviderInterface;
namespace BaiduScholarProvider
{
    public class AbstractParser : IParser<HtmlNode>
    {
        public string Parse(HtmlNode item) 
            => item.SelectSingleNode(RuleSet.AbstractPath)?.InnerText;
    }
}
