using LassoReader.Parsing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasso.UnitTests
{
    [TestFixture]
    public class DataRowParserTests
    {
        private DataRowParser _dataRowParser;

        [SetUp]
        public void init()
        {
            _dataRowParser = new DataRowParser();
        }

        [TearDown]
        public void dctor() 
        {
            _dataRowParser = null;
        }

        [TestCase(@"1234.2      23     2222", 3)]
        public void ParseRow_ValidRowState_ReturnsCorrectElementCount(string row, int columns)
        {
            string[] line = _dataRowParser.ParseRow(row);

            Assert.AreEqual(line.Length, columns, "Parse rows returned unexpected columns counts.");
        }



    }
}
