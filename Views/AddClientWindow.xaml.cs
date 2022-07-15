using System.Windows;
using Microsoft.Extensions.Logging;
using Utils;
using System.Data;
using System.Windows.Data;
using System.Windows.Navigation;
using Repositories;
using System.Collections.ObjectModel;

namespace Views
{
    public partial class AddClientWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("MainWindow");

        public AddClientWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();
        }
    }
}
