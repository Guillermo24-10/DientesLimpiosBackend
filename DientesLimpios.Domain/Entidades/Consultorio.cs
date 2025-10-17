using DientesLimpios.Domain.Exceptions;

namespace DientesLimpios.Domain.Entidades
{
    public class Consultorio
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }

        public Consultorio(string nombre)
        {
            if(string.IsNullOrWhiteSpace(nombre))
            {
                throw new ExceptionDeReglaDeNegocio($"El {nameof(nombre)} es obligatorio");
            }

            Nombre = nombre;
            Id = Guid.CreateVersion7();
        }
    }
}
