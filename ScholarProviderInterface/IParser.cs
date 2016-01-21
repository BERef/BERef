using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarProviderInterface
{
    public interface IParser<T>
    {
        string Parse(T item);
    }
}
