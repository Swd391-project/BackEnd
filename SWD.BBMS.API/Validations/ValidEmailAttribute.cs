using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.Validations
{
    public class ValidEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || string.IsNullOrEmpty(value.ToString()))
        {
            // If email is not provided, it's valid
            return ValidationResult.Success;
        }

        // Perform email validation if it is provided
        var email = value.ToString();
        if (new EmailAddressAttribute().IsValid(email))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Invalid email address.");
    }
    }
}
