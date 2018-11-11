using CMS.Login.Interfaces;
using CMS.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;

namespace CMS.Login
{
    public class LoginViewModel : BaseViewModel
    {
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

        #region commands
        public RelayCommand Login { get; set; }

        private void OnTryLogin(object rootElement)
        {
            if (!(rootElement is IDialogResult view))
                throw new NullReferenceException("View of view model cannot be null");
            view.DialogResult = true;
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_email)
                    && _password.Length != 0
                    && !_errors.Any()
                    && !_busy;
        }
        #endregion

        #region validation
        protected override void ValidateProperty(object value, [CallerMemberName]string propertyName = null)
        {
            base.ValidateProperty(value, propertyName);
            Login.OnCanExecuteChanged();
        }
        #endregion
    }
}
