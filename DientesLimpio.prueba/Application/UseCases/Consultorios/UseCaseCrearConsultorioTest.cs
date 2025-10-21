using DientesLimpios.Application.Excepciones;
using DientesLimpios.Application.Interfaces.Persistencia;
using DientesLimpios.Application.Interfaces.Repositorio;
using DientesLimpios.Application.UseCases.Consultorios.Commands.CrearConsultorio;
using DientesLimpios.Domain.Entidades;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using System.Diagnostics;

namespace DientesLimpio.prueba.Application.UseCases.Consultorios
{
    [TestClass]
    public class UseCaseCrearConsultorioTest
    {
        private IRepositorioConsultorios _repositorioConsultorios;
        private IUnitOfWork _unitOfWork;
        private IValidator<CrearConsultorioCommand> _validator;
        private CrearConsultorioHandler _handler;

        [TestInitialize]
        public void Setup()
        {
            _repositorioConsultorios = Substitute.For<IRepositorioConsultorios>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _validator = Substitute.For<IValidator<CrearConsultorioCommand>>();
            _handler = new CrearConsultorioHandler(_repositorioConsultorios, _unitOfWork, _validator);
        }

        [TestMethod]
        public async Task Handle_ComandoValido_ObtenemosIdConsultorio()
        {
            Debugger.Launch();
            var comando = new CrearConsultorioCommand { Nombre = "Consultorio 1" };

            _validator.ValidateAsync(comando).Returns(new ValidationResult());

            var consultorioCreado = new Consultorio("Consultorio 1");
            _repositorioConsultorios.Crear(Arg.Any<Consultorio>()).Returns(consultorioCreado);

            var resultado = await _handler.Handle(comando, CancellationToken.None);

            await _validator.Received(1).ValidateAsync(comando);
            await _repositorioConsultorios.Received(1).Crear(Arg.Any<Consultorio>());
            await _unitOfWork.Received(1).Commit();
            Assert.AreNotEqual(Guid.Empty, resultado);
        }

        [TestMethod]
        public async Task Handle_ComandoNoValido_LanzaExcepcion()
        {
            var comando = new CrearConsultorioCommand { Nombre = "" };
            var errores = new List<ValidationFailure>
            {
                new ValidationFailure("Nombre", "El nombre es obligatorio")
            };
            var resultadoValidacion = new ValidationResult(errores);
            _validator.ValidateAsync(comando).Returns(resultadoValidacion);
            await Assert.ThrowsExceptionAsync<ExcepcionValidator>(async () =>
            {
                await _handler.Handle(comando, CancellationToken.None);
            });
            await _repositorioConsultorios.DidNotReceive().Crear(Arg.Any<Consultorio>());
        }

        [TestMethod]
        public async Task Handle_CuandoHayError_HacemosRollback()
        {
            var comando = new CrearConsultorioCommand { Nombre = "Consultorio 1" };
            _validator.ValidateAsync(comando).Returns(new ValidationResult());
            _repositorioConsultorios.Crear(Arg.Any<Consultorio>()).Returns<Task<Consultorio>>(x => { throw new Exception("Error al crear consultorio"); });
            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await _handler.Handle(comando, CancellationToken.None);
            });
            await _unitOfWork.Received(1).Rollback();
        }
    }
}
