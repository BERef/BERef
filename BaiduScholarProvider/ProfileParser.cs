using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScholarProviderInterface;

namespace BaiduScholarProvider
{
    public class ProfileParser : IParser<HtmlNode>
    {
        public string Parse(HtmlNode item)
        {
            // Get profile, it includes authors, year, publish.
            var authors = item.SelectNodes(RuleSet.AuthorsPath);
            var authorList = new StringBuilder();
            if (authors != null)
            {
                foreach (var author in authors)
                {
                    authorList.Append(author.InnerText);
                    authorList.Append(RuleSet.Separator);
                }
                authorList.Remove(authorList.Length - RuleSet.Separator.Length, RuleSet.Separator.Length);
            }
            else authorList.Append(RuleSet.None);
            var publish = item.SelectSingleNode(RuleSet.PublishPath)?.InnerText ?? RuleSet.None;
            var year = item.SelectSingleNode(RuleSet.YearPath)?.InnerText ?? RuleSet.None;

            return $"{authorList.ToString()} - {publish} - {year}";
        }
    }
}
