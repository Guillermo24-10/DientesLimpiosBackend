using DientesLimpios.Domain.Exceptions;

namespace DientesLimpios.Domain.ValueObject
{
    public record IntervaloDeTiempo
    {
        public DateTime Inicio { get; }
        public DateTime Fin { get; }

        public IntervaloDeTiempo(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                throw new ExceptionDeReglaDeNegocio($"La fecha de inicio no puede ser anterior a la fecha actual");
            }

            Inicio = fechaInicio;
            Fin = fechaFin;
        }
    }
}
