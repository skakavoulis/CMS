using System.Windows;
using System.Windows.Controls;

namespace CMS.Clients
{
    /// <summary>
    /// Interaction logic for ClientsView.xaml
    /// </summary>
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
        }

        private void MainView_OnLoaded(object sender, RoutedEventArgs e)
        {
            var modelView = DataContext as ClientsViewModel;
            modelView.OnLoadClients(null);
        }
    }
}
