using FluentValidation.Results;

namespace DientesLimpios.Application.Excepciones
{
    public class ExcepcionValidator : Exception
    {
        public List<string> ErroresValidator { get; set; } = [];

        public ExcepcionValidator(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                ErroresValidator.Add(error.ErrorMessage);
            }
        }
    }
}
