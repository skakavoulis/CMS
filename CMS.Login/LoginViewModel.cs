using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows;
using CMS.Tools;

namespace CMS.Login
{
    public class LoginViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _email;
        [EmailAddress]
        [StringLength(int.MaxValue, MinimumLength = 5)]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                ValidateProperty(value);
                OnPropertyChanged();
            }
        }

        private SecureString _password;
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                ValidateProperty(value);
                OnPropertyChanged();
            }
        }

        private bool _busy;
        public bool Busy
        {
            get => _busy;
            set
            {
                _busy = value;
                Login.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }


        public LoginViewModel()
        {
            Login = new RelayCommand(OnTryLogin, CanLogin);
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region commands
        public RelayCommand Login { get; set; }

        private void OnTryLogin(object view)
        {
            if (!(view is Window window))
                throw new NullReferenceException("");
            window.DialogResult = true;
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_email)
                    && _password.Length != 0
                    && !_errors.Any()
                    && !_busy;
        }
        #endregion

        #region data validation
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public IEnumerable<string> Errors => _errors.SelectMany(x => x.Value);

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.ContainsKey(propertyName)
                ? _errors[propertyName]
                : null;
        }

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void ValidateProperty(object value, [CallerMemberName] string propertyName = null)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };
            Validator.TryValidateProperty(value, context, results);
            if (results.Any())
                _errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            else
                _errors.Remove(propertyName);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(Errors));
            Login.OnCanExecuteChanged();
        }
        #endregion
    }
}
