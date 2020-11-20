using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InstanciarListaVentas()
        {
            try
            {
                PlayStation PS = new PlayStation();
                Venta<PlayStation> venta = new Venta<PlayStation>();

                venta.listaProductos.Add(PS);

                Assert.IsNotNull(venta.listaProductos);
            }
            catch (NullReferenceException)
            {
                Assert.Fail("No se pudo instanciar la lista de ventas");
            }
        }
    }
}
