using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso.Tests
{
    [TestClass]
    public class AsciiTests
    {
        [TestMethod]
        public void AsciiCompare_CarriageReturn_Pass()
        {
            Assert.AreEqual(13, (int)'\r');
        }

        [TestMethod]
        public void AsciiCompare_LineFeed_Pass()
        {
            Assert.AreEqual(10, (int)'\n');
        }

        [TestMethod]
        public void AsciiCompare_NewLine_Pass()
        {
            //only in windows is \r\n valid
            Assert.AreEqual(Environment.NewLine, "\r\n");
        }
    }
}
