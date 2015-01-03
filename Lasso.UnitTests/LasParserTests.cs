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

        [TestCase("7900.80   -999.25   047.00", 3)]
        [TestCase("1 2 3 4      5    6             7", 7)]
        public void ParseDataRow_ValidDataRow_ReturnsCorrectCols(string row, int expectedLength)
        {
            string[] currentRow = row.Trim().Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(expectedLength, currentRow.Length);

        }

        [TestCase("FLD   .           2nd Bone Springs               : Field", "FLD", "", "2nd Bone Springs", "Field")]
        [TestCase("STEP  .FT         0.20                           : STEP", "STEP", "FT", "0.20", "STEP")]
        [TestCase("STEP  .FT         0.20 :::: A                           : STEP UP ", "STEP", "FT", "0.20 :::: A", "STEP UP")]
        [TestCase("STEP.FT 0.20:A:B:C:LAST", "STEP", "FT", "0.20:A:B:C", "LAST")]
        [TestCase("PDAT  .           Mean Sea Level                 : Permanent Datum", "PDAT","","Mean Sea Level", "Permanent Datum")]
        public void ParseSectionRow_ValidSectionRow_ReturnsLasSectionItem(string row, string mnemonic, string unit, string data, string desc)
        {
            var lasso = new SectionRowParser();

            var result = lasso.ParseRow(row);

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

        [Test]
        public void Parse_MultiSectionInput_ShouldInsertRowsIntoSections()
        {
            var input = @"~VERSION
                          FLD .FT 2.0 : TEST
                          FGH .FT 32 : FGH
                          ~WELL
                          WTF .M 23.2 : WOW";
            MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(input));
            var lasso = makeParser();

            var result = lasso.Parse(ms);

            Assert.AreEqual(2, result.Version.Items.Count);
            Assert.AreEqual(1, result.Well.Items.Count);
        }

    }
}
