using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso
{
    public interface ILasParser<T> where T : class
    {
        IEnumerable<T> ParseHeader(string filePath);
        Task<IEnumerable<T>> ParseHeadrerAsync(string filePath);
        IEnumerable<T> ParseDataRow(string filePath);
        Task<IEnumerable<T>> ParseDataRowAsync(string filePath);
        //oops did we violate SRP already?
    }
}
