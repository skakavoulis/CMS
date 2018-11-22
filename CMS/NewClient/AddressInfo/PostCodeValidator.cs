using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CMS.NewClient.AddressInfo
{
    public class PostCodeValidator : ValidationRule
    {
        public int Size { get; set; } = 5;
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value as string;
            if (string.IsNullOrWhiteSpace(input))
                return new ValidationResult(false, "Postcode is required");
            if (input.Length != Size)
                return new ValidationResult(false, $"Postcode needs to be {Size} characters");

            if (!Regex.IsMatch(input, @"^[0-9]*$"))
            {
                return new ValidationResult(false, $"Can only contain numbers");
            }

            return ValidationResult.ValidResult;
        }
    }
}