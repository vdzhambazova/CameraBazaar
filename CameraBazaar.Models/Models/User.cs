using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegex;

namespace CameraBazaar.Models.Models
{
    public class User
    {
        public User()
        {
            this.Cameras = new HashSet<Camera>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4), MaxLength(20)]
        [RegularExpression(UsernameLettersRegex, ErrorMessage = UsernameLettersMessage)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [RegularExpression(PasswordValidationRegex, ErrorMessage = PasswordValidationMessage)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(PhoneValidationRegex, ErrorMessage = PhoneValidationMessage)]
        public string Phone { get; set; }

        public virtual ICollection<Camera> Cameras { get; set; }
    }
}