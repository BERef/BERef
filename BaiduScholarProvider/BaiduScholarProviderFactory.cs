using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScholarProviderInterface;

namespace BaiduScholarProvider
{
    public class BaiduScholarProviderFactory : IScholarProviderFactory
    {
        public ISearchProvider Create()
        {
            return new WebSearchProvider(
                new Loader(),
                new Spliter(),
                new BriefBuilder());
        }
    }
}
