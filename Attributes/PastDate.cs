using System.ComponentModel.DataAnnotations;

namespace ContactListWeb.Attributes
{
    public class PastDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date && date <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The date cannot be future.");
        }
    }
}
