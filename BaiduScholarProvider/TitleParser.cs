using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScholarProviderInterface;
namespace BaiduScholarProvider
{
    public class TitleParser : IParser<HtmlNode>
    {
        #region Implement 'IParser'
        public string Parse(HtmlNode item)
        {
            return item.SelectSingleNode(RuleSet.TitlePath)?.InnerText;
        }
        #endregion
    }
