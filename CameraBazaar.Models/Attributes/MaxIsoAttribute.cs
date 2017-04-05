using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.Attributes
{
    public class MaxIsoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int iso = (int)value;
            bool isoDevidableBy100 = iso % 100 == 0;
            if (iso >= 200 && iso <= 409600 && isoDevidableBy100)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(MaxIsoValidationMessage);
        }
    }
}
