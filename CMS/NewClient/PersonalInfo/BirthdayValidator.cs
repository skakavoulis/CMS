using System;
using System.Globalization;
using System.Windows.Controls;

namespace CMS.NewClient.PersonalInfo
{
    public class BirthdayValidator : ValidationRule
    {
        public int MinimumAge { get; set; } = 18;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Birthday is required");

            var input = (DateTime)value;
            if ((DateTime.Now - input).Days * 365 < MinimumAge)
                return new ValidationResult(false, $"Client must be over {MinimumAge} years old to register");

            return ValidationResult.ValidResult;
        }
    }
}
