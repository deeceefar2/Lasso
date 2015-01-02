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

        [TestCase(" A ", "A")]
        [TestCase("  A B  C     ", "A B  C")]
        public void StringBuilderTrim_InputWithWhiteSpace_ReturnsTrimedString(string input, string expectedOutput)
        {
            StringBuilder inputSB = new StringBuilder(input);
            inputSB.Trim();

            StringAssert.AreEqualIgnoringCase(inputSB.ToString(), expectedOutput);
        }
    }
}
