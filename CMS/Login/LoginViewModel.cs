using System.ComponentModel;

namespace CMS.Login
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            this.Email = "test@email.com";
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }

}
