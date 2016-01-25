using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScholarProviderInterface;
using HtmlAgilityPack;

namespace GoogleScholarProvider
{
    public class Spliter : ISpliter<HtmlDocument, HtmlNode>
    {

        #region Implement 'ISpliter'
        public IEnumerable<HtmlNode> Split(HtmlDocument dataSource)
        {
            var nodes = dataSource.DocumentNode.SelectNodes(RuleSet.EntryPath);

            foreach (var node in nodes)
            {
                yield return node;
            }
        }
        #endregion
    }
}
