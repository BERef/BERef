using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScholarProviderInterface;

namespace BaiduScholarProvider
{
    public class Loader : ILoader<HtmlDocument>
    {
        #region Implement 'ILoader'
        public HtmlDocument Load(string keyword)
        {
            var htmlWeb = new HtmlWeb();
            return htmlWeb.Load($"{RuleSet.BaiduScholarUrl}/s?wd={keyword}");
        }
        #endregion
    }
}
