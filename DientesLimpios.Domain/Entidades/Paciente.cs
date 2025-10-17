using DientesLimpios.Domain.Exceptions;
using DientesLimpios.Domain.ValueObject;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DientesLimpios.Domain.Entidades
{
    public class Paciente
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;  
        public Email Email { get; private set; }

        public Paciente(string nombre, Email email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ExceptionDeReglaDeNegocio($"El {nameof(nombre)} es obligatorio");
            }
            if (email == null)
            {
                throw new ExceptionDeReglaDeNegocio($"El {nameof(email)} es obligatorio");
            }

            Id = Guid.CreateVersion7();
            Nombre = nombre;
            Email = email;
        }
    }
}
