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
    public class DataRowParser : ILasRowParser<Dictionary<string, List<string>>>
    {
        private LasSection _curve;
        private Dictionary<string, List<string>> _result;

        public DataRowParser()
        {
            //_curve = curve;
            //_result = SetupDataHeader(_curve);
        }

        public Dictionary<string, List<string>> ParseRow(string row)
        {
            string[] data = row.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < data.Length-1; i++)
            {
                _result.ElementAt(i).Value.Add(data[i]);
            }

            return _result;
        }

        private Dictionary<string, List<string>> SetupDataHeader(LasSection curve)
        {
            var initialzedDictionary = new Dictionary<string, List<string>>();

            foreach (var item in curve.Items)
            {
                initialzedDictionary.Add(item.Mnemonic, new List<string>());
            }

            return initialzedDictionary;
        }
    }
}
