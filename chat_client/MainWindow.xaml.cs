using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using chat_client.ServiceReferenceChat;

namespace chat_client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,chat_client.ServiceReferenceChat.IServiceChatCallback
    {
        private bool _isConnected = false;
        private ServiceReferenceChat.ServiceChatClient _client;
        private int _idClient;
        public MainWindow()
        {
            InitializeComponent();
        }

        void ConnectClient()
        {
            if (!_isConnected)
            {
                _client = new ServiceChatClient(new InstanceContext(this));
                _idClient = _client.Connect(TxbNameClient.Text);
                TxbNameClient.IsEnabled = false;
                BtnStartStop.Content = "Disconnect";
                _isConnected = true;
            }
        }

        void DisconnectClient()
        {
            if (_isConnected)
            {
                _client.Disconnect(_idClient);
                _client = null;
                TxbNameClient.IsEnabled = true;
                BtnStartStop.Content = "Connect";
                _isConnected = false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isConnected)
            {
                DisconnectClient();
            }
            else
            {
                ConnectClient();
            }
        }

        public void InfoCallback(string context)
        {
            LbxAllChat.Items.Add(context);
            LbxAllChat.ScrollIntoView(LbxAllChat.Items[LbxAllChat.Items.Count-1]);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectClient();
        }

        private void TxbSendMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _client?.SendInfo(TxbSendMsg.Text,_idClient);
                TxbSendMsg.Text = string.Empty;
            }
        }
    }
}
