using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net.NetworkInformation;

namespace Всякие_приколюхи
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Host;
        string Ping;
        string Buffer;
        string TimeOut;
        String Options;
        public MainWindow()
        {
            InitializeComponent();

        }
        public bool Check()
        {
            var ping = new Ping();
            string host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            var options = new PingOptions();
            try
            {
                var reply = ping.Send(host, timeout, buffer, options);
                return reply.Status == IPStatus.Success;
                Host = host;
                Ping = Convert.ToString(ping);
                Buffer = Convert.ToString(buffer);
                TimeOut = Convert.ToString(timeout);
                Options = Convert.ToString(options);
            }
            catch (PingException)
            {
                return false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (Check()==true)
            {
                InfoStatus.Content = "Соединение установлено";
                /*Info.Content = $"Host - {Host}\t " +
                    $"Ping - {Ping}\t " +
                    $"Buffer - {Buffer}\t" +
                    $"TimeOut - {TimeOut}" +
                    $"Options - {Options}";
                */
            }
            else
            {
                InfoStatus.Content = "Соединение не установлено";
            }
        }
    }
}
