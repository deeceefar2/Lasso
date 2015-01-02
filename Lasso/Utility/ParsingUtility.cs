using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Utility
{
    public static class ParsingUtility
    {
        /// <summary>
        /// Removes all white space from a string
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpace(this string row)
        {
            return new string(row
                              .Where(c => !char.IsWhiteSpace(c))
                              .ToArray());
        }

        /// <summary>
        /// Removes leading and ending whitespace from a StringBuilder
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        public static StringBuilder Trim(this StringBuilder sb)
        {
            if (sb == null || sb.Length == 0)
            {
                return sb;
            }
            else
            {
                var temp = sb.ToString().Trim();
                sb.Clear();
                sb.Append(temp);

                return sb;
            }
        }
    }
}
