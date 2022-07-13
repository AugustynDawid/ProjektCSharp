using System;
using System.Net;
using Microsoft.Extensions.Logging;
using Utils;
using System.Threading;


namespace Proxy
{
    public sealed class Relay
    {
        private static readonly ILogger logger = AppLoggerFactory.GetLogger("Relay");

        private static Relay? instance;

        public static Relay StartInstance(int port)
        {
            if (instance != null)
            {
                throw new InvalidOperationException("Instance already created");
            }

            logger.LogInformation(String.Format("Starting Relay on port {0}", port));
            instance = new Relay();
            instance.Listen(port);
            return instance;
        }

        public static Relay GetInstance()
        {
            if (instance == null)
            {
                throw new InvalidOperationException("Instance not created");
            }

            return instance;
        }
        private Relay() { }

        private bool shouldHandleRequests = true;

        private readonly HttpListener listener = new HttpListener();

        public void Listen(int port)
        {
            var portPrefix = String.Format("http://localhost:{0}/", port);
            logger.LogInformation(String.Format("Relay starting at {0}", portPrefix));
            this.listener.Prefixes.Add(portPrefix);
            this.listener.Start();
            SetupListener();
        }

        public void Close()
        {
            logger.LogInformation("Closing Relay");
            shouldHandleRequests = false;
            listener.Close();
        }

        private void SetupListener()
        {
            var handler = new Thread(HandleRequests);
            handler.Start();
        }

        private void HandleRequests()
        {
            while (shouldHandleRequests)
            {
                HttpListenerContext context;
                try
                {
                    context = listener.GetContext();
                }
                catch
                {
                    continue;
                }


                logger.LogDebug("Received request");
                if (context != null)
                {
                    InterceptRequest(context);
                }
            }
        }

        private void InterceptRequest(HttpListenerContext ctx)
        {
            var req = ctx.Request;
            if (req == null)
            {
                logger.LogWarning("Received empty request");
                return;
            }
        }
    }
}
