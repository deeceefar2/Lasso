using LassoReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LassoReader.Parsing
{
    public interface ILasParser
    {
        LasResult Parse(Stream stream);
        LasResult ParseAsync(Stream stream);
    }
}
