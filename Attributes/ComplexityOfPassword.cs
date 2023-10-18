using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ContactListWeb.Attributes
{
    public class ComplexityOfPassword : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var lowercase = "[a-z]";
            var uppercase = "[A-Z]";
            var digits = "[0-9]";

            if(value is string password && 
                Regex.IsMatch(password, lowercase) && 
                Regex.IsMatch(password, uppercase) && 
                Regex.IsMatch(password, digits))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The password must contain at least one lower case letter, one upper case letter and a number.");
        }
    }
}
