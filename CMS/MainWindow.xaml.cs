using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;

namespace CMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ButtonController OkButtonController { get; set; } = new ButtonController();

        public MainWindow()
        {
            InitializeComponent();
            CancelButton.DataContext = new ButtonController();
            OkButton.DataContext = OkButtonController;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            OkButtonController.LoaderVisible = Visibility.Visible;
            var timer = new Timer();
            timer.Interval = 2000;
            timer.Elapsed += (s, args) =>
            {
                OkButtonController.LoaderVisible = Visibility.Hidden;
                timer.Stop();
            };
            timer.Start();
        }

        public class ButtonController : INotifyPropertyChanged
        {
            private Visibility _loaderVisible = Visibility.Hidden;

            public Visibility LoaderVisible
            {
                get
                {
                    return _loaderVisible;
                }
                set
                {
                    if (_loaderVisible != value)
                    {
                        _loaderVisible = value;
                        NotifyPropertyChanged();
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
