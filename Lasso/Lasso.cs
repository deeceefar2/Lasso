using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LassoReader
{
    public class Lasso 
    {
        private Stream _fileStream;

        public Lasso(Stream fileStream)
        {
            _fileStream = fileStream;
            
        }

    }
}
