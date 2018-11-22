using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CMS.NewClient.AddressInfo
{
    public class CountryValidator : ValidationRule
    {
        public int MinSize { get; set; } = 3;

        public int MaxSize { get; set; } = 5;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value as string;
            if (string.IsNullOrWhiteSpace(input))
                return new ValidationResult(false, "Country is required");
            if (input.Length < MinSize)
                return new ValidationResult(false, $"Country needs to be at least {MinSize} characters");
            if (input.Length > MaxSize)
                return new ValidationResult(false, $"Country needs to be under {MaxSize} characters");
            if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                return new ValidationResult(false, $"Can only contain letters");

            return ValidationResult.ValidResult;
        }
    }
}