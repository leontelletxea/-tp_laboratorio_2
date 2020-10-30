using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace UnitTestProject1
{
    [TestClass]
    public class Test_DniInvalidoException
    {
        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                Alumno alumno1 = new Alumno(1, "Pepe", "Pistolas", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alumno2 = new Alumno(1, "Pepe", "Pistolas", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail("No se lanzo la excepcion de tipo DniInvalidoException");
            }
            catch (Excepciones.NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(Excepciones.NacionalidadInvalidaException));
            }
        }
    }
}
