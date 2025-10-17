using DientesLimpios.Domain.Enums;

namespace DientesLimpios.Domain.Entidades
{
    public class Cita
    {
        public Guid Id { get; private set; }
        public Guid PacienteId { get; private set; }
        public Guid DentistaId { get; private set; }
        public Guid ConsultorioId { get; private set; }
        public EstadoCita Estado { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }
        public Paciente? Paciente { get; private set; }
        public Dentista? Dentista { get; private set; }
        public Consultorio? Consultorio { get; private set; }
    }
}
