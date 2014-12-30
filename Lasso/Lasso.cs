using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso
{
    class Lasso : ILasHeaderParser<LasHeaderModel>, ILasDataParser<LasDataModel>
    {
        public IEnumerable<LasHeaderModel> ParseHeader(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LasHeaderModel>> ParseHeaderAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LasDataModel> ParseDataRow(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LasDataModel>> ParseDataRowAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
