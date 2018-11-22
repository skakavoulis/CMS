using CMS.Tools;
using CMS.NewClient.AddressInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace CMS.NewClient.AddressInfo
{
    public class AddressInfoViewModel : BaseViewModel, IDataErrorInfo
    {
        private new Dictionary<string, string> _errors;

        public AddressInfoViewModel()
        {
            _errors = new Dictionary<string, string>();
        }

        private string _streetName;
        public string StreetName
        {
            get => _streetName;
            set
            {
                SetPropertyValue(ref _streetName, value);
                Validate(value, new CountryValidator());
            }
        }

        private string _postCode;
        public string PostCode
        {
            get => _postCode;
            set
            {
                SetPropertyValue(ref _postCode, value);
                Validate(value, new PostCodeValidator());
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                SetPropertyValue(ref _city, value);
                Validate(value, new CityValidator());
            }
        }

        private string _country;
        public string Country
        {
            get => _country;
            set
            {
                SetPropertyValue(ref _country, value);
                Validate(value, new CountryValidator());
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (_errors.ContainsKey(columnName))
                    return _errors[columnName];
                return null;
            }
        }

        public string Error => _errors
            .Select(x => x.Value)
            .FirstOrDefault();

        public override bool HasErrors => string.IsNullOrWhiteSpace(StreetName)
                                          || string.IsNullOrWhiteSpace(PostCode)
                                          || _errors.Any();


        private void Validate(object value, ValidationRule validator)
        {
            var error = validator.Validate(value, null);
            if (!error.IsValid)
                _errors[nameof(StreetName)] = error.ErrorContent as string;
            else
                _errors.Remove(nameof(StreetName));
            OnErrorsChanged();
        }
    }
}