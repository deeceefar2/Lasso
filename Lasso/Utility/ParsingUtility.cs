using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Utility
{
    public static class ParsingUtility
    {
        public static string RemoveWhiteSpace(this string row)
        {
            return new string(row
                              .Where(c => !char.IsWhiteSpace(c))
                              .ToArray());
        }
    }
}
