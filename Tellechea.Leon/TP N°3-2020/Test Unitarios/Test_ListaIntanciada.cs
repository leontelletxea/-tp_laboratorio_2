using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace UnitTestProject1
{
    [TestClass]
    public class Test_ListaIntanciada
    {
        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                Universidad universidad = new Universidad();
                Assert.IsNotNull(universidad.Instructores);
            }
            catch (NullReferenceException e)
            {
                Assert.Fail("No se pudo instanciar la lista de alumnos");
            }


        }
    }
}
