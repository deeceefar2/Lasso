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
            var lasso = new SectionRowParser();

            Stopwatch start = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                lasso.ParseRow("STEP  .FT         0.20 :::: A                           : STEP UP ");
            }
            start.Stop();
            Console.WriteLine("Concat time in ms: " + start.ElapsedMilliseconds);



            Console.WriteLine("Stream test...");
            MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes("~VERSION TEST"));
            using (TextReader tr = new StreamReader(ms))
            {
                char result = (char)tr.Read();
                Console.WriteLine(result);
                AdvanceReader(tr);
                char result2 = (char)tr.Read();
                Console.WriteLine(result2);
            }





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

        public static void AdvanceReader(TextReader tr)
        {
          char result = (char)tr.Read();
          Console.WriteLine(result);
        }
    }
}
