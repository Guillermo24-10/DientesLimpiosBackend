using DientesLimpios.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Domain.ValueObject
{
    public record Email
    {
        public string Valor { get; } = string.Empty;
        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ExceptionDeReglaDeNegocio($"El {nameof(email)} es obligatorio");
            }

            if (!email.Contains("@"))
            {
                throw new ExceptionDeReglaDeNegocio($"El {nameof(email)} no es válido");
            }

            Valor = email;
        }
    }
}
