using DientesLimpios.Application.Interfaces.Repositorio;
using DientesLimpios.Domain.Entidades;
using MediatR;

namespace DientesLimpios.Application.UseCases.Consultorios.Commands.CrearConsultorio
{
    public class CrearConsultorioHandler : IRequestHandler<CrearConsultorioCommand, Guid>
    {
        private readonly IRepositorioConsultorios _repositorioConsultorios;

        public CrearConsultorioHandler(IRepositorioConsultorios repositorioConsultorios)
        {
            _repositorioConsultorios = repositorioConsultorios;
        }

        public async Task<Guid> Handle(CrearConsultorioCommand request, CancellationToken cancellationToken)
        {
            var consultorio = new Consultorio(request.Nombre);
            var respuesta = await _repositorioConsultorios.Crear(consultorio);
            return respuesta.Id;
        }
    }
}
