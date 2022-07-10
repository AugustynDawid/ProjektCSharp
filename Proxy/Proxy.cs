using System;
using System.Net;
using Microsoft.Extensions.Logging;
using Utils;

namespace Proxy
{
    public class Relay
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("Relay");
        private readonly HttpListener listener = new HttpListener();

        public void Listen(int port)
        {
            var portPrefix = String.Format("http://*:{0}/", port);
            logger.LogInformation(String.Format("Relay starting at {}", portPrefix));
            this.listener.Prefixes.Add(portPrefix);
            this.listener.Start();
        }
    }
}
