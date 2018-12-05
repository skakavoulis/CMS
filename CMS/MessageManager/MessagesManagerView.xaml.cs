using CMS.Services.Interfaces;
using System;
using System.ServiceModel;
using System.Windows;

namespace CMS.MessageManager
{
    /// <summary>
    /// Interaction logic for MessagesManagerView.xaml
    /// </summary>
    public partial class MessagesManagerView : Window
    {
        private ServiceHost _host;
        private IMessagesService _msgs;

        public MessagesManagerView()
        {
            InitializeComponent();

            _msgs = App.MessagesFactory.InstatiateService();
            IdTextBox.Text = Guid.NewGuid().ToString("N");
        }

        private void StartManagerClick(object sender, RoutedEventArgs e)
        {
            _host = new ServiceHost(typeof(MessageManager));
            _host.AddServiceEndpoint(
                typeof(IMessageManager),
                new NetNamedPipeBinding(),
                $"net.pipe://localhost/messages/{IdTextBox.Text}");
            _host.Open();
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            MessageButton.IsEnabled = true;
        }

        private void StopManagerClick(object sender, RoutedEventArgs e)
        {
            _host.Close();
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            MessageButton.IsEnabled = false;
        }

        private void SendMessageClick(object sender, RoutedEventArgs e)
        {
            _msgs.SendMessage("Hello World", RecipientIsdTextBox.Text);
        }
    }
}
