using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Constants
{
    /// <summary>
    /// Delimiters found in a .LAS file,
    /// ~ - signifies the start of a new section header
    /// # - is a comment we want to ignore any comment lines
    /// . - before the . is the mnemonic, directly after that . is the units if used.
    /// : - to left of the colon is the data, to the right of the colon is the description.
    /// </summary>
    public class Delimiters
    {
        public const string SECTIONBEGIN = "~";
        public const string COMMENT = "#";
        public const char DOT = '.';
        public const char COLON = ':';
    }
}
