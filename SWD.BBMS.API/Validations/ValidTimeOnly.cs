using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.Validations
{
    public class ValidTimeOnly : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("From time and to time is required.");
            }

            var timeOnly = value.ToString().Trim();
            var time = timeOnly.Split(' ');
            var timeParts = time[0].Split(':');
            var result = int.TryParse(timeParts[0], out int hour);

            if (!result || hour < 0 || hour > 23)
            {
                return new ValidationResult("Invalid hour.");
            }
            result = int.TryParse(timeParts[1], out int minute);
            if (!result || (minute != 0 && minute != 30))
            {
                return new ValidationResult("Invalid minute.");
            }
            
            return ValidationResult.Success;
        }
    }
}
