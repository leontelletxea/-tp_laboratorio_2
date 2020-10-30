using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace UnitTestProject1
{
    [TestClass]
    public class NacionalidadInvalidaException
    {
        [TestMethod]
        public void TestMethod3()
        {
            try
            {
                Alumno a = new Alumno(1, "Pepe", "Pistolas", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

                Assert.Fail("No se lanzo la excepcion de tipo NacionalidadInvalidaException");
            }
            catch(Excepciones.NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(Excepciones.NacionalidadInvalidaException));
            }

        }
    }
}
