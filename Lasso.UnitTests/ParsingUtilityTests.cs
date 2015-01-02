using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LassoReader.Utility;

namespace Lasso.UnitTests
{
    [TestFixture]
    public class ParsingUtilityTests
    {
        [TestCase("a b c", "abc")]
        public void RemoveWhiteSpace_InputWithSpaces_ShouldRemoveSpaces(string input, string result)
        {
            input = input.RemoveWhiteSpace();

            StringAssert.AreEqualIgnoringCase(input, result);
        }
    }
}
