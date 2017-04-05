using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Constants;

namespace CameraBazaar.Models.BindingModels
{
    public class LoginUserBindingModel
    {
        [Required]
        [MinLength(4), MaxLength(20)]
        [RegularExpression(ValidationRegex.UsernameLettersRegex, ErrorMessage = ValidationMessages.UsernameLettersMessage)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [RegularExpression(ValidationRegex.PasswordValidationRegex, ErrorMessage = ValidationMessages.PasswordValidationMessage)]
        public string Password { get; set; }
    }
}
