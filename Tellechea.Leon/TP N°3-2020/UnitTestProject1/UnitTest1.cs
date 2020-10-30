using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_NacionalidadInvalidaException ()
        {
            try
            {
                Alumno a = new Alumno(1, "Walter", "White", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

                a.DNI = 70000000;

                Assert.Fail("No se encontro una excepcion de tipo NacionalidadInvalidaException...");
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void Test_DniInvalidoException()
        {
            try
            {
                Alumno a = new Alumno(1, "Pedro", "Perez", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

                Assert.Fail("No se encontro una excepcion de tipo DniInvalidoException...");
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void Test_AlumnoRepetidoException()
        {
            try
            {
                Universidad u = new Universidad();
                Alumno a = new Alumno(1, "Walter", "White", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

                u += a;
                u += a;

                Assert.Fail("No se encontro una excepcion de tipo AlumnoRepetidoException...");
            }
            catch (AlumnoRepetidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void Test_InstanciarListaDeAlumnos()
        {
            try
            {
                Universidad universidad = new Universidad();
                Assert.IsNotNull(universidad.Alumnos);
            }
            catch (NullReferenceException e)
            {

                Assert.Fail("La lista Alumnos de Universidad no se pudo instanciar");
            }
        }
    }
}
