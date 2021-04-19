using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RDC.Tests.UnitTest
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void SaveRianTest()
        {
            var soldiers = 5;
            var expectedResult = 3;

            var result = SaveRian.Program.KillSoldiers(soldiers);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
