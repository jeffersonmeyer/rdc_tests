using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RDC.Tests.UnitTest
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void SaveRianTest()
        {
            var soldados = 5;
            var resultadoEsperado = 3;

            var resultado = SaveRian.Program.ObterPosicaoDeSorte(soldados);

            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}
