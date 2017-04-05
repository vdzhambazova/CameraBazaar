namespace CameraBazaar.Models.Constants
{
    public class ValidationMessages
    {
        public const string UsernameLettersMessage = "Username must contain only letters.";
        public const string PasswordValidationMessage = "Password must contain only lowercase letters and numbers.";
        public const string PhoneValidationMessage = "Phone must start with + and must contain 10-12 numbers.";
        public const string ModelValidationMessage = "Model must only contain uppercase letters, numbers and dash.";
        public const string MinIsoValidationMessage = "Min ISO must be 50 or 100.";
        public const string MaxIsoValidationMessage = "Max ISO must be between200 to 409600 and must be dividable by 100.";
        public const string ImageUrlValidationMessage = "Image URL should start with http:// or https://.";
    }
}
