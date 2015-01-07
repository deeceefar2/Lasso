using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Models
{
    public class LasAsciiData
    {
        public List<string[]> LogAsciiData { get; private set; }

        public LasAsciiData()
        {
            LogAsciiData = new List<string[]>();
        }
    }
}
