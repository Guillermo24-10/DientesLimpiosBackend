

using MediatR;

namespace DientesLimpios.Application.UseCases.Consultorios.Commands.CrearConsultorio
{
    public class CrearConsultorioCommand : IRequest<Guid>
    {
        public required string Nombre { get; set; }
    }
}
