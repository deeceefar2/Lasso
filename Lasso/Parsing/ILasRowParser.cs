using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Parsing
{
    public interface ILasRowParser<T> 
    {
        T ParseRow(string row);
    }
}
