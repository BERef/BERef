using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibCrawler
{
    public interface ICrawler
    {
        /// <summary>
        /// Search by keyword.
        /// </summary>
        /// <param name="keyword"></param>
        void Search(string keyword);

        /// <summary>
        /// Get search result list.
        /// </summary>
        /// <returns></returns>
        IList<BriefEntry> GetList();

        /// <summary>
        /// Get BibTex by search result item.
        /// </summary>
        /// <param name="briefEntry"></param>
        /// <returns></returns>
        string GetBibTex(BriefEntry briefEntry);
    }
}
