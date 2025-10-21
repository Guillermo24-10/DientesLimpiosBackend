using DientesLimpios.Application.Excepciones;
using DientesLimpios.Application.Interfaces.Persistencia;
using DientesLimpios.Application.Interfaces.Repositorio;
using DientesLimpios.Domain.Entidades;
using FluentValidation;
using MediatR;

namespace DientesLimpios.Application.UseCases.Consultorios.Commands.CrearConsultorio
{
    public class CrearConsultorioHandler : IRequestHandler<CrearConsultorioCommand, Guid>
    {
        private readonly IRepositorioConsultorios _repositorioConsultorios;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CrearConsultorioCommand> _validator;

        public CrearConsultorioHandler(IRepositorioConsultorios repositorioConsultorios, IUnitOfWork unitOfWork, IValidator<CrearConsultorioCommand> validator)
        {
            _repositorioConsultorios = repositorioConsultorios;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Guid> Handle(CrearConsultorioCommand request, CancellationToken cancellationToken)
        {
            var resultValidacion = await _validator.ValidateAsync(request);

            if (!resultValidacion.IsValid)
            {
                throw new ExcepcionValidator(resultValidacion);
            }

            var consultorio = new Consultorio(request.Nombre);
            try
            {
                var respuesta = await _repositorioConsultorios.Crear(consultorio);
                await _unitOfWork.Commit();
                return respuesta.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
