using DientesLimpios.Domain.Exceptions;
using DientesLimpios.Domain.ValueObject;

namespace DientesLimpios.Domain.Entidades
{
    public class Dentista
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public Email Email { get; private set; }

        public Dentista(string nombre, Email email)
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
