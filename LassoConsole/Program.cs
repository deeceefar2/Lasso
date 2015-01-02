using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LassoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LassoReader.Parsing.LasParser lasso = new LassoReader.Parsing.LasParser();

            Stopwatch start = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                lasso.ParseSectionRow("STEP  .FT         0.20 :::: A                           : STEP UP ");
            }
            start.Stop();
            Console.WriteLine("Concat time in ms: " + start.ElapsedMilliseconds);


            //Stopwatch start2 = Stopwatch.StartNew();
            //for (int i = 0; i < 1000; i++)
            //{
            //    lasso.ParseSectionRowWithBuilder("STEP  .FT         0.20 :::: A                           : STEP UP ");
            //}
            //start2.Stop();
            //Console.WriteLine("Concat time in ms: " + start2.ElapsedMilliseconds);

            Console.WriteLine("Perf test done..");
            Console.Read();
            
        }
    }
}
