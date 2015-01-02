using LassoReader.Parsing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso.UnitTests
{
    [TestFixture]
    public class LasParserTests
    {
        private LasParser makeParser()
        {
            return new LasParser();
        }

        [Ignore]
        [TestCase("~v")]
        [TestCase(" ~  V asdfghytrew")]
        public void Parse_SectionHeaderInput_ReturnsLasResult(string row)
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(row));
            var lasso = makeParser();

            var result = lasso.Parse(stream);

            Assert.AreEqual(1, result.Version.Items.Count);
        }

        [TestCase("STEP  .FT         0.20                           : STEP")]
        public void ParseSectionRow_ValidSectionRow_ReturnsLasSectionItem(string row)
        {
            var lasso = makeParser();

            var result = lasso.ParseSectionRow(row);

            StringAssert.AreEqualIgnoringCase(result.Mnemonic, "STEP");
            StringAssert.AreEqualIgnoringCase(result.Unit, "FT");
            StringAssert.AreEqualIgnoringCase(result.Data, "0.20");


        }
    }
}
