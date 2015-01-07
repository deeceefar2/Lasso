using LassoReader.Constants;
using LassoReader.Models;
using LassoReader.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LassoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"~VERSION
                          FLD .FT 2.0 : TEST
                          FGH .FT 32 : FGH
                          ~WELL
                          WTF .M 23.2 : WOW
                          ~C
                          DEPTH .FT : Depth
                          MTF .DEG : Magnetic ToolFace
                          ~ASCII
                          23 30.5
                          25 45.0";

            var lasso = new LasParser();
            var lasResult = lasso.Parse(new MemoryStream(Encoding.ASCII.GetBytes(input)));

            Console.WriteLine(lasResult);
            Console.Read();
        }
    }
}
