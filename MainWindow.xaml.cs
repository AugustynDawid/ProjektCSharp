using System;
using System.Windows;
using Microsoft.Extensions.Logging;
using Utils;

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
    }
}
