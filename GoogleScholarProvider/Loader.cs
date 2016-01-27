using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScholarProviderInterface;
using HtmlAgilityPack;

namespace GoogleScholarProvider
{
    public class Loader : ILoader<HtmlDocument>
    {
        #region Implement 'ILoader'
        public HtmlDocument Load(string keyword)
        {
            var htmlWeb = new HtmlWeb();
            return htmlWeb.Load($"{RuleSet.GoogleScholarSearchURL}{keyword}");
        }
        #endregion
    }
}
