using System.Windows;
using Microsoft.Extensions.Logging;
using Utils;
using Views;

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

        private void AddClient(object sender, RoutedEventArgs e)
        {
            var window = new AddClientWindow();
            window.Show();
        }

        private void ManageClients(object sender, RoutedEventArgs e)
        {
            var window = new ListClientsWindow();
            window.Show();
        }
    }
}
