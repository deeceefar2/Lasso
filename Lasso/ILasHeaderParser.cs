using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso.Parser
{
    public interface ILasHeaderParser<T> where T : class
    {
        IEnumerable<T> ParseWellHeader(string filePath);
        Task<IEnumerable<T>> ParseWellHeaderAsync(string filePath);
        IEnumerable<T> ParseVersionHeader(string filePath);
        Task<IEnumerable<T>> ParseVersionHeaderAsync(string filePath);
        IEnumerable<T> ParseCurveHeader(string filePath);
        Task<IEnumerable<T>> ParseCurveHeaderAsync(string filePath);
    }
}
