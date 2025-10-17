namespace DientesLimpios.Domain.Entidades
{
    public class Paciente
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;  
        public string Email { get; private set; } = string.Empty;   
    }
}
