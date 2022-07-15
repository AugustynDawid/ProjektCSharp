using System.Windows;
using Microsoft.Extensions.Logging;
using Utils;

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
