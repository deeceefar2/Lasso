using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;

namespace Lasso.Tests
{
    [TestClass]
    public class HeaderParsingTests
    {
        [TestMethod]
        public void HeaderLineParse_WithSpaceTilde_Pass()
        {
            var shortAsciiHeader = " ~A";
            Assert.AreEqual(Lasso.Sections.ASCIIDATA, shortAsciiHeader.TrimStart());
        }

        [TestMethod]
        public void HeaderLineParse_CurveFullHeaderSection_Pass()
        {
            var curveHeader = " ~CURVE INFORMATION";
            var builtCurve = new StringBuilder();
            foreach (var character in curveHeader.TrimStart().Take(2))
            {
                builtCurve.Append(character);
            }
            Assert.AreEqual(Lasso.Sections.CURVEINFO, builtCurve.ToString());
        }

        [TestMethod]
        public void HeaderLineParseSection_WhiteSpaceTest_Pass()
        {
            StringBuilder input = new StringBuilder();
            input.Append("~VERSION INFORMATION" + Environment.NewLine);
            input.Append("VERS  .           2.0                            : CWLS LOG ASCII STANDARD 2.0" + Environment.NewLine);
            input.Append("WRAP  .           NO                             : ONE LINE PER DEPTH STEP" + Environment.NewLine);
            input.Append("~WELL INFORMATION");

            StringBuilder section = new StringBuilder();
            //StringBuilder headerData = new StringBuilder();

            bool sectionBegin = false;
            //bool inData = false;

            //goal is to extract which section we're at and the data in the section to be further parsed
            MemoryStream fs = null;
            try
            {
                fs = new MemoryStream(Encoding.ASCII.GetBytes(input.ToString()));
                using (TextReader tr = new StreamReader(fs, Encoding.UTF8))
                {
                    
                    char c;
                    while (true)
                    {
                        c = (char)tr.Read();

                        if (c == '\r')
                            return;

                        if (!sectionBegin)
                        {
                            if (char.IsWhiteSpace(c))
                            {
                                continue;
                            }
                            else if (c == Lasso.Sections.SECTIONBEGIN)
                            {
                                sectionBegin = true;
                                section.Append(Lasso.Sections.SECTIONBEGIN);
                                section.Append((char)tr.Peek());
                            }
                        }
                    }
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }

            //foreach(var character in headerLine)
            //{
            //    if(char.IsWhiteSpace(character))
            //    {
            //        whitespaceCount++;
            //    }
            //}

            Assert.AreEqual(section, Lasso.Sections.VERSIONINFO);
        }


    }
}
