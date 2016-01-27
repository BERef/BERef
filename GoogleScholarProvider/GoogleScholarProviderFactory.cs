using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScholarProviderInterface;

namespace GoogleScholarProvider
{
    public class GoogleScholarProviderFactory : IScholarProviderFactory
    {
        #region Implement 'IScholarProviderFactory'
        public ISearchProvider Create()
        {
            return new WebSearchProvider(
                new Loader(),
                new Spliter(),
                new BriefBuilder());
        }
        #endregion

    }
}
