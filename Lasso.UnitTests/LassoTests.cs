using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LassoReader.UnitTests
{
    [TestFixture]
    public class LassoTests
    {
        private Lasso MakeLasso()
        {
            return new Lasso(null);
        }

        [TestCase(".las")]
        [TestCase(".LAS")]
        public void IsValidExtension_LowerCase_Pass(string filePath)
        {
            ////acquire
            //var lasso = MakeLasso();

            ////act
            //var result = lasso.IsValidLasExtension(filePath);

            ////assert
            //Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsFluent()
        {
            //var lasso = MakeLasso();

            //var ex = Assert.Catch<Exception>(() => lasso.IsValidLasExtension(""));

            //Assert.That(ex.Message, Is.StringContaining("File path cannot be null or empty."));
        }
    }
}
