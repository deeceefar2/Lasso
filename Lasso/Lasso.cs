using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso
{
    class Lasso : ILasParser<string> 
    {

        public IEnumerable<string> ParseHeader(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> ParseHeadrerAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ParseDataRow(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> ParseDataRowAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
