using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Constants;

namespace CameraBazaar.Models.ViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        [RegularExpression(ValidationRegex.UsernameLettersRegex, ErrorMessage = ValidationMessages.UsernameLettersMessage)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(ValidationRegex.PasswordValidationRegex, ErrorMessage = ValidationMessages.PasswordValidationMessage)]
        public string Password { get; set; }
    }
}
