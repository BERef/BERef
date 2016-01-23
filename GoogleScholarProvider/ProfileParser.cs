using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScholarProviderInterface;
using HtmlAgilityPack;

namespace GoogleScholarProvider
{
    public class ProfileParser : IParser<HtmlNode>
    {
        #region Implement 'IParser'
        public string Parse(HtmlNode item)
        {
            return item.SelectSingleNode(RuleSet.ProfilePath)?.InnerText;
        }
        #endregion
    }
}
