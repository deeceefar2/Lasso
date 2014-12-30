using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso.UnitTests
{
    [TestFixture]
    public class AsciiTests
    {
        [TestCase(13, '\r')]
        [TestCase(10, '\n')]
        public void LasAsciiSet_ValidCharacter_ReturnsTrue(int asciiCode, char c)
        {
            Assert.True(asciiCode == (int)c);
        }
    }
}
