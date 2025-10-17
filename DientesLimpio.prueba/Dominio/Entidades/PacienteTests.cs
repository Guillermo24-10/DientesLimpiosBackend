using DientesLimpios.Domain.Entidades;
using DientesLimpios.Domain.Exceptions;
using DientesLimpios.Domain.ValueObject;

namespace DientesLimpio.prueba.Dominio.Entidades
{
    [TestClass]
    public class PacienteTests
    {
        [TestMethod]
        [ExpectedException(typeof(ExceptionDeReglaDeNegocio))]
        public void Constructor_NombreNulo_LanzaException()
        {
            var email = new Email("demo@gmail.com");
            new Paciente(null!, email);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionDeReglaDeNegocio))]
        public void Constructor_EmailNulo_LanzaException()
        {
            Email email = null!;
            new Paciente("Demo", email);
        }
    }
}
