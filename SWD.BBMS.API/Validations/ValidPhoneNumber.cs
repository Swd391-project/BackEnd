using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.Validations
{
    public class ValidPhoneNumber : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || string.IsNullOrEmpty(value.ToString()))
            {
                // If phone number is not provided, it's valid
                return ValidationResult.Success;
            }

            // Perform phone number validation if it is provided
            var phoneNumber = value.ToString();
            if (new PhoneAttribute().IsValid(phoneNumber))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid phone number.");
        }
    }
}
