using CMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace CMS.NewClient.PersonalInfo
{
    public class PersonalInfoViewModel : BaseViewModel, IDataErrorInfo
    {
        private new Dictionary<string, string> _errors;

        public PersonalInfoViewModel()
        {
            _errors = new Dictionary<string, string>();
            Birthday = DateTime.Now;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                SetPropertyValue(ref _name, value);
                Validate(value, new NameValidator());
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                SetPropertyValue(ref _lastName, value);
                Validate(value, new NameValidator());
            }
        }

        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                SetPropertyValue(ref _birthday, value);
                Validate(value, new BirthdayValidator());
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

        public override bool HasErrors => string.IsNullOrWhiteSpace(Name)
                                          || string.IsNullOrWhiteSpace(LastName)
                                          || _errors.Any();


        private void Validate(object value, ValidationRule validator)
        {
            var error = validator.Validate(value, null);
            if (!error.IsValid)
                _errors[nameof(Name)] = error.ErrorContent as string;
            else
                _errors.Remove(nameof(Name));
            OnErrorsChanged();
        }
    }
}