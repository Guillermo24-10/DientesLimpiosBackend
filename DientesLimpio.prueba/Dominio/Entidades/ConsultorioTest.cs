using DientesLimpios.Domain.Entidades;
using DientesLimpios.Domain.Exceptions;

namespace DientesLimpio.prueba.Dominio.Entidades
{
    [TestClass]
    public class ConsultorioTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExceptionDeReglaDeNegocio))]
        public void Constructor_NombreNulo_LanzaException()
        {
            new Consultorio(null!);
        }
    }
}
