using System;
using Entidades;
using Entidades.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void ImprimirTicket()
        {
            try
            {
                bool retValue = false;
                PlayStation p = new PlayStation(1, 600, 1000, "2020", "PlayStation5");
                retValue = Tickets<PlayStation>.ImprimirTiket(p);

                Assert.IsTrue(retValue);
            }
            catch(Exception e)
            {
                throw new ArchivosException("Error al imprimir el ticket", e);
            }
        }
    }
}
