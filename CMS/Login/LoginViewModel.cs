using CMS.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CMS.Login
{
    public class LoginViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly ILoginService _loginService;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _email;
        [Required]
        [EmailAddress]
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

        private string _password;
        [Required]
        [MinLength(5)]
        public string Password
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
            _loginService = App.LoginFactory.InstatiateService();
            Login = new LoginCommand(OnTryLogin, CanLogin);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region commands
        public LoginCommand Login { get; set; }

        public CancelCommand Cancel { get; set; } = new CancelCommand();

        private async void OnTryLogin()
        {
            Busy = true;
            var authToken = await _loginService.Authenticate(_email, _password);
            MessageBox.Show(authToken);
            Busy = false;
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(_email)
                    && !string.IsNullOrWhiteSpace(_password)
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
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(Errors));
            Login.OnCanExecuteChanged();
        }
        #endregion
    }
}
