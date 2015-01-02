using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Constants
{
    //Each LAS file consists of sections. Sections begin with a header line defined as beginning with
    //the ~ tilde character when it occurs as the first non-space character on a line. The character
    //immediately following the tilde character defines the section with the remainder of the line
    //being ignored. The characters "V", "W", "C", "P", "O", and "A" are reserved in the LAS 2.0
    //standard. The sections defined by the LAS 2.0 standard are limited to one occurrence per file.
    //Customer defined sections are permitted but must be located after the first section (~V) and
    //before the last section (~A). 
    public class Sections
    {
        //sections
        public const string VERSIONINFO = "v";
        public const string WELLINFO = "W";
        public const string CURVEINFO = "C";
        public const string PARAMETERINFO = "P";
        public const string OTHER = "O";
        public const string ASCIIDATA = "A";
    }
}
