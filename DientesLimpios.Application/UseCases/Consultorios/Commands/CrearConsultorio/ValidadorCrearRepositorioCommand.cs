using FluentValidation;

namespace DientesLimpios.Application.UseCases.Consultorios.Commands.CrearConsultorio
{
    public class ValidadorCrearRepositorioCommand : AbstractValidator<CrearConsultorioCommand>
    {
        public ValidadorCrearRepositorioCommand()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.");             
        }
    }
}
