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
    /// Interaction logic for ProxyWindow.xaml
    /// </summary>
    public partial class ProxyWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("ProxyWindow");

        public ProxyWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();
        }
    }
}
