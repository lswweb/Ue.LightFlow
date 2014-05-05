using System;

namespace Ue.LightFlow.Infrastructure.Logging
{
     class NullLoggerFactory : ILoggerFactory {
        public ILogger CreateLogger(Type type) {
            return NullLogger.Instance;
        }
    }
}