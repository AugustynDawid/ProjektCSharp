using System.Windows;
using Microsoft.Extensions.Logging;
using Utils;
using Proxy;
using System.ComponentModel;

namespace ProjektCSharp
{
    /// <summary>
    /// Interaction logic for ProxyWindow.xaml
    /// </summary>
    public partial class RequestsWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("RequestsWindow");

        public RequestsWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();
        }

        public void OnWindowClosing(object? sender, CancelEventArgs e)
        {
            logger.LogInformation("Handling window closing");
            var relay = Proxy.Relay.GetInstance();
            relay.Close();
        }
    }
}
