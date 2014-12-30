using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso
{
    public interface ILasHeaderParser<T> where T : class
    {
        IEnumerable<T> ParseHeader(string filePath);
        Task<IEnumerable<T>> ParseHeadrerAsync(string filePath);
    }
}
