using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarProviderInterface
{
    public interface ISearchProvider
    {
        #region Public Abstract Method
        IList<BriefEntry> GetResults(string keyword);
        #endregion
    }
}
