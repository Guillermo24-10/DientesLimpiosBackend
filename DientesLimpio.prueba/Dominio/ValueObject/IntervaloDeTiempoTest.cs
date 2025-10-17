using DientesLimpios.Domain.Exceptions;
using DientesLimpios.Domain.ValueObject;

namespace DientesLimpio.prueba.Dominio.ValueObject
{
    [TestClass]
    public class IntervaloDeTiempoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExceptionDeReglaDeNegocio))]
        public void Constructor_FechaInicioPosteriorALaFechaFin_LanzaExcepcion()
        {
            new IntervaloDeTiempo(DateTime.UtcNow, DateTime.UtcNow.AddDays(-1));
        }

        [TestMethod]
        public void Constructor_ParametrosCorrectos_NoLanzaExcepcion()
        {
            new IntervaloDeTiempo(DateTime.UtcNow, DateTime.UtcNow.AddDays(30));
        }
    }
}
