using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarProviderInterface
{
    public abstract class SearchProvider<DataSource, T>
    {
        #region Private Field
        private ILoader<DataSource> _loader;
        private ISpliter<DataSource, T> _spliter;
        private IBuilder<T> _builder;
        #endregion

        #region Public Abstract Method
        public abstract IList<BriefEntry> GetResults(string keyword);
        #endregion
    }
}
