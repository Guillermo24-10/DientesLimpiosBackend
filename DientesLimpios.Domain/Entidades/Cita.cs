using DientesLimpios.Domain.Enums;
using DientesLimpios.Domain.Exceptions;
using DientesLimpios.Domain.ValueObject;

namespace DientesLimpios.Domain.Entidades
{
    public class Cita
    {
        public Guid Id { get; private set; }
        public Guid PacienteId { get; private set; }
        public Guid DentistaId { get; private set; }
        public Guid ConsultorioId { get; private set; }
        public EstadoCita Estado { get; private set; }
        public IntervaloDeTiempo IntervaloDeTiempo { get; private set; }
        public Paciente? Paciente { get; private set; }
        public Dentista? Dentista { get; private set; }
        public Consultorio? Consultorio { get; private set; }

        public Cita(Guid pacienteId, Guid dentistaId, Guid consultorId, IntervaloDeTiempo intervaloDeTiempo)
        {
            if (intervaloDeTiempo.Inicio < DateTime.UtcNow)
            {
                throw new ExceptionDeReglaDeNegocio($"La fecha de inicio no puede ser anterior a la fecha actual");
            }

            PacienteId = pacienteId;
            DentistaId = dentistaId;
            ConsultorioId = consultorId;
            IntervaloDeTiempo = intervaloDeTiempo;
            Estado = EstadoCita.Programada;
            Id = Guid.CreateVersion7();
        }

        public void Cancelar()
        {
            if (Estado == EstadoCita.Programada)
            {
                throw new ExceptionDeReglaDeNegocio("Solo se pueden cancelar citas programadas.");
            }

            Estado = EstadoCita.Cancelada;
        }

        public void Completar()
        {
            if (Estado != EstadoCita.Programada)
            {
                throw new ExceptionDeReglaDeNegocio("Solo se pueden completar citas programadas.");
            }
            Estado = EstadoCita.Completada;
        }
    }
}
