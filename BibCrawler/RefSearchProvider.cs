using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibCrawler
{
    public abstract class RefSearchProvider
    {
        #region Const Field
        /// <summary>
        /// Split symbol.
        /// </summary>
        protected static string _separator = ", ";
        /// <summary>
        /// Empty field.
        /// </summary>
        protected static string _none = "None";
        #endregion

        #region Abstract Method
        /// <summary>
        /// Get search result list.
        /// </summary>
        /// <returns></returns>
        public abstract IList<BriefEntry> GetResult();

        /// <summary>
        /// Get BibTex by search result item.
        /// </summary>
        /// <param name="briefEntry"></param>
        /// <returns></returns>
        //string GetBibTex(BriefEntry briefEntry);
        #endregion
    }
}
