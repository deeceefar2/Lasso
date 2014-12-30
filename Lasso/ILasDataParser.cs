using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso
{
    public interface ILasDataParser<T> where T : class
    {
        IEnumerable<T> ParseDataRow(string filePath);
        Task<IEnumerable<T>> ParseDataRowAsync(string filePath);
    }
}
