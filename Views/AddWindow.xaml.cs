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
    public partial class AddWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("MainWindow");

        public AddWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();
        }
    }
}
