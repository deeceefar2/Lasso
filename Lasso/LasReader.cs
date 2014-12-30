using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lasso.Parser
{
    public class LasReader : ILasHeaderParser<LasHeaderModel>, ILasDataParser<LasDataModel>
    {
        private const string LASEXTENSION = ".las";

        public bool IsValidLasExtension(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty.");

            return filePath.EndsWith(LASEXTENSION, StringComparison.OrdinalIgnoreCase);
        }

        protected IEnumerable<LasHeaderModel> ParseHeader(string filePath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (TextReader tr = new StreamReader(fs))
                {
                    fs = null;
                    yield return new LasHeaderModel { Data = tr.ReadLine() };
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
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

        public IEnumerable<LasHeaderModel> ParseWellHeader(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LasHeaderModel>> ParseWellHeaderAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LasHeaderModel> ParseVersionHeader(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LasHeaderModel>> ParseVersionHeaderAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LasHeaderModel> ParseCurveHeader(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LasHeaderModel>> ParseCurveHeaderAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
