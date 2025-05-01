using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;

namespace _bibliotecaApi.Validaciones
{
    public class PrimeraLetraMayusculaAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var valuestring = value.ToString()!;
            var primeraLetra= valuestring[0].ToString();

            if (primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("la primera letra tiene que esta en mayuscula");
            }
            return ValidationResult.Success;



        }

    }
}
