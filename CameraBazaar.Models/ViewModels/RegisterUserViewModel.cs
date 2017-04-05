using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Constants;

namespace CameraBazaar.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [MinLength(4), MaxLength(20)]
        [RegularExpression(ValidationRegex.UsernameLettersRegex, ErrorMessage = ValidationMessages.UsernameLettersMessage)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [RegularExpression(ValidationRegex.PasswordValidationRegex, ErrorMessage = ValidationMessages.PasswordValidationMessage)]
        public string Password { get; set; }

        [Required]
        [MinLength(3)]
        [RegularExpression(ValidationRegex.PasswordValidationRegex, ErrorMessage = ValidationMessages.PasswordValidationMessage)]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(ValidationRegex.PhoneValidationRegex, ErrorMessage = ValidationMessages.PhoneValidationMessage)]
        public string Phone { get; set; }
    }
}
