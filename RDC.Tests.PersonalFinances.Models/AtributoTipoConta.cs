using System.ComponentModel.DataAnnotations;

namespace RDC.Tests.PersonalFinances.Models
{
    public class AtributoTipoConta: ValidationAttribute
    {
        public AtributoTipoConta() { }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext) 
        {
            var strValor = value.ToString();
            if (string.IsNullOrEmpty(strValor))
            {
                return new ValidationResult($"O campo {validationContext.DisplayName} precisa ser preenchido!");
            }

            if(strValor.ToUpper()!="D" && strValor.ToUpper() != "C")
            {
                return new ValidationResult($"O campo {validationContext.DisplayName} só aceita os valores 'C' ou 'D'"); 
            }

            return ValidationResult.Success;
        }
    }
}
