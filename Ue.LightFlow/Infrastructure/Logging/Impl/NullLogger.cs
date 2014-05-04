using System;

namespace Ue.LightFlow.Infrastructure.Logging
{
    public class NullLogger : ILogger {
        private static readonly ILogger instance = new NullLogger();

        public static ILogger Instance {
            get { return instance; }
        }

        public bool IsEnabled(LogLevel level) {
            return false;
        }

        public void Log(LogLevel level, Exception exception, string format, params object[] args) {
        }
    }
}