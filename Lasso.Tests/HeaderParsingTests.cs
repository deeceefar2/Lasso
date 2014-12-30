using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

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
    }
}
