using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Client_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Client _client;

        public int PortNumber { get; set; }
        public IPAddress IpAddress => _client.IpAddress;
        public string HostName { get { return _client.HostName; } set { _client.HostName = value; } }
        public string Message { get; set; }
        public string OutputMessage => _client.OutputMessage;


        public bool ButtonCheckConnectionEnabled { get; set; }
        public bool ButtonSendMessageEnabled { get; set; }

        public MainWindow()
        {
            _client = new Client();
            InitializeComponent();
            ButtonCheckConnection.IsEnabled = false;
            ButtonSendMessage.IsEnabled = false;
        }

        private void ChangedPortNumber(object sender, TextChangedEventArgs e)
        {
            try
            {
                PortNumber = Int32.Parse(TxtPortNumber.Text);
            }
            catch
            {
                TxtOutputMessage.Text += "NOT VALID PORTNUMBER!\n";
            }
            if (IpAddress != null && !IpAddress.Equals(""))
            {
                ButtonCheckConnectionEnabled = true;
                ButtonCheckConnection.IsEnabled = true;
            }
        }

        private void ChangedIpAddress(object sender, TextChangedEventArgs e)
        {
           // IpAddress = IPAddress.Parse(TxtIpAddress.Text);
            if (PortNumber != 0)
            {
                ButtonCheckConnectionEnabled = true;
            }
        }
        private void ChangedHostName(object sender, TextChangedEventArgs e)
        {
            HostName = TxtHostName.Text;
        }
        private void MessageChanged(object sender, RoutedEventArgs e)
        {
            Message = TxtMessage.Text;
        }
        private void ReplyChanged(object sender, RoutedEventArgs e)
        {

        }
        private void ChangedLogger(object sender, RoutedEventArgs e)
        {
            
        }
        private void ChangedReply(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonCheckConnection_OnClick(object sender, RoutedEventArgs e)
        {
            int exitCode = -1;
            try
            {
                exitCode = _client.ConnectToServer(PortNumber);
                //exitCode = 0;
            }
            catch (Exception ex)
            {
                TxtOutputMessage.Text = "ERROR CONNECTING TO SERVER\n" + ex.Message;
                exitCode = -1;
            }
            if (exitCode == 0)
            {
                MessageBox.Show("Connection successfull!");
                ButtonSendMessageEnabled = true;
                ButtonSendMessage.IsEnabled = true;
                ButtonCheckConnection.Background = Brushes.Green;
            }
            else
            {
                MessageBox.Show("ERROR");
                ButtonCheckConnection.Background = Brushes.DarkRed;
            }
        }
        private void ButtonSendMessage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
