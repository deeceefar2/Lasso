using LassoReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Parsing
{
    /// <summary>
    /// Parses the log data, and get it's columns from the curve section.
    /// </summary>
    public class DataRowParser : ILasRowParser<string[]>
    {
        public string[] ParseRow(string row)
        {
            return row.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
