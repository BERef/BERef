using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;
using ScholarProviderInterface;

namespace GoogleScholarProvider
{
    public class TitleParser : IParser<HtmlNode>
    {
        #region Implement 'IParser'
        public string Parse(HtmlNode item)
        {
            var title = item.SelectSingleNode(RuleSet.TitlePath);
            var titleBuilder = new StringBuilder();
            foreach (var t in title.ChildNodes)
            {
                if (t.Name != "span")
                    titleBuilder.Append(t.InnerText);
            }
            return titleBuilder.ToString().Trim();
        }
        #endregion
    }
}
