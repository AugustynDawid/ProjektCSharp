using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows;
using Proxy;
using Microsoft.Extensions.Logging;
using Utils;
using System.Windows.Navigation;


namespace ProjektCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("MainWindow");

        public MainWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();
        }

        private void StartProxy_Btn_Click(object sender, RoutedEventArgs e)
        {
            var portString = Port_TBox.Text;
            logger.LogInformation(String.Format("Trying to start proxy on port {0}", portString));
            var port = int.Parse(portString);
            Proxy.Relay.StartInstance(port);
        }
    }
}
