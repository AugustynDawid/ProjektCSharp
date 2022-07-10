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

namespace ProjektCSharp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application


    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("App");

        protected override void OnStartup(StartupEventArgs e)
        {
            this.logger.LogInformation("Booting application");
            base.OnStartup(e);
            this.BootComponents(e);
        }

        private void BootComponents(StartupEventArgs e)
        {
            this.logger.LogInformation("Booting custom components");
            var proxyThread = new Thread(() =>
            {
                var proxy = new Relay();
                proxy.Listen(1234);
            });
            proxyThread.Start();
        }
    }
}
