namespace CameraBazaar.Models.Constants
{
    public class ValidationRegex
    {
        public const string UsernameLettersRegex = ("^[a-zA-Z ]*$");
        public const string PasswordValidationRegex = ("^[a-z0-9]*$");
        public const string PhoneValidationRegex = ("^\\+[0-9]{10,12}$");
        public const string ModelValidationRegex = ("^[A-Z0-9\\-]+$");
        public const string ImageUrlValidationRegex = ("^(http:\\/\\/|https:\\/\\/)$");
    }
}
