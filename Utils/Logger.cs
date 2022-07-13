using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Utils
{
    public class AppLoggerFactory
    {
        private static ILoggerFactory _Factory = LoggerFactory.Create(builder =>
        {
            builder.ClearProviders();
            builder.AddConsole();
        });
        public static ILogger GetLogger(string name)
        {
            var logger = _Factory.CreateLogger(name);
            return logger;
        }
    }
}