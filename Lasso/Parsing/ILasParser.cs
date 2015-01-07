using LassoReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LassoReader.Parsing
{
    public interface ILasParser<T> where T : class
    {
        T Parse(Stream stream);
        T ParseAsync(Stream stream);
    }
}
