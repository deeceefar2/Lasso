using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LassoReader.Models
{
    /// <summary>
    /// The result of a successful parsed .LAS files will be returned as a LasResult.
    /// </summary>
    public class LasResult
    {
        public LasSection Version { get; private set; }
        public LasSection Well { get; private set; }
        public LasSection Curve { get; private set; }
        public LasSection Parameter { get; private set; }
        public LasSection Other { get; private set; }
        public LasAsciiData DataRows { get; set; }
        public string Error { get; set; }

        public LasResult()
        {
            Version = new LasSection();
            Well = new LasSection();
            Curve = new LasSection();
            Parameter = new LasSection();
            Other = new LasSection();
            DataRows = new LasAsciiData();
        }
    }
}
