using LassoReader.Models;
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

        [TestCase("FLD   .           2nd Bone Springs               : Field", "FLD", "", "2nd Bone Springs", "Field")]
        [TestCase("STEP  .FT         0.20                           : STEP", "STEP", "FT", "0.20", "STEP")]
        [TestCase("STEP  .FT         0.20 :::: A                           : STEP UP ", "STEP", "FT", "0.20 :::: A", "STEP UP")]
        [TestCase("STEP.FT 0.20:A:B:C:LAST", "STEP", "FT", "0.20:A:B:C", "LAST")]
        [TestCase("PDAT  .           Mean Sea Level                 : Permanent Datum", "PDAT","","Mean Sea Level", "Permanent Datum")]
        public void ParseSectionRow_ValidSectionRow_ReturnsLasSectionItem(string row, string mnemonic, string unit, string data, string desc)
        {
            var lasso = makeParser();

            var result = lasso.ParseSectionRow(row);

            StringAssert.AreEqualIgnoringCase(result.Mnemonic, mnemonic);
            StringAssert.AreEqualIgnoringCase(result.Unit, unit);
            StringAssert.AreEqualIgnoringCase(result.Data, data);
            StringAssert.AreEqualIgnoringCase(result.Description, desc);
        }

        [Test]
        public void StringBuilder_BlankInput_ReturnsNotNull()
        {
            StringBuilder b = new StringBuilder();
            Assert.That(b.ToString(), !Is.Null);
            Assert.That(b.ToString(), Is.Empty);
            StringAssert.AreEqualIgnoringCase(b.ToString(), "");
        }

    }
}
