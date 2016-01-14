using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibCrawler
{

    public abstract class RefSearchProvider<Item>
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

        #region Protected Method
        /// <summary>
        /// Parse all items. 
        /// </summary>
        /// <returns></returns>
        protected IList<BriefEntry> Parse()
        {
            var briefEntryList = new List<BriefEntry>();

            foreach (var pair in ParsePairs())
            {
                var item  = pair.Item1;
                var entry = pair.Item2;

                entry.Profile  = ParseProfile(item);
                entry.Title    = ParseTitle(item);
                entry.Abstract = ParseAbstract(item);

                briefEntryList.Add(entry);
            }

            return briefEntryList;
        }
        #endregion

        #region Public Abstract Method
        /// <summary>
        /// Get search result list.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public abstract IList<BriefEntry> GetResult(string keyword);
        #endregion

        #region Private Abstract Method
        /// <summary>
        /// Parse all special property of items. 
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<Tuple<Item, BriefEntry>> ParsePairs();

        /// <summary>
        /// Parse to BrifEntry's title.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected abstract string ParseTitle(Item item);

        /// <summary>
        /// Parse to BrifEntry's profile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected abstract string ParseProfile(Item item);

        /// <summary>
        /// Parse to BrifEntry's Abstract.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected abstract string ParseAbstract(Item item);
        #endregion
    }
}
