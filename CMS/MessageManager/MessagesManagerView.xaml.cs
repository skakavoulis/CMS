using CMS.Services.Interfaces;
using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
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
        private SynchronizationContext _syncContext;

        public MessagesManagerView()
        {
            InitializeComponent();

            _msgs = App.MessagesFactory.InstatiateService();
            _msgs.MessageReceived += _msgs_MessageReceived;

            IdTextBox.Text = Guid.NewGuid().ToString("N");
            _syncContext = SynchronizationContext.Current;
        }

        private void _msgs_MessageReceived(object sender, MessageReceivedDelegateArgs args)
        {
            var callback = new SendOrPostCallback(arg =>
            {
                MessageReceivedTextBlock.Text = args.Message;
            });
            _syncContext.Send(callback, null);
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

        private async void SendMessageClick(object sender, RoutedEventArgs e)
        {
            var message = MessageTextBox.Text;
            var recipient = RecipientIsdTextBox.Text;
            await Task.Run(() =>
             {
                 var msgs = App.MessagesFactory.InstatiateService();
                 msgs.SendMessage(message, recipient);
             });
        }
    }
}
