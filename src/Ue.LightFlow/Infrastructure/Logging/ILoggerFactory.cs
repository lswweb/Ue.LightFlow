using System;

namespace Ue.LightFlow.Infrastructure.Logging
{
    /// <summary>
    /// 日志对象创建工厂
    /// </summary>
    public interface ILoggerFactory
    {
        ILogger CreateLogger(Type type);
    }
}
