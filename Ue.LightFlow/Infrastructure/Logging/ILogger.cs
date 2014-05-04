using System;

namespace Ue.LightFlow.Infrastructure.Logging
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 是否已开启指定等级的日志
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="level">等级</param>
        /// <param name="exception">异常</param>
        /// <param name="format">日志消息格式化</param>
        /// <param name="args">消息格式化参数</param>
        void Log(LogLevel level, Exception exception, string format, params object[] args);
    }

    public static class LoggingExtensions
    {
        #region debug

        public static void Debug(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Debug, null, message, null);
        }

        public static void Debug(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Debug, null, format, args);
        }

        public static void Debug(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Debug, exception, message, null);
        }

        public static void Debug(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Debug, exception, format, args);
        }

        #endregion

        #region  Information

        public static void Information(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Information, null, message, null);
        }

        public static void Information(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Information, null, format, args);
        }

        public static void Information(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Information, exception, message, null);
        }
        public static void Information(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Information, exception, format, args);
        }

        #endregion

        #region Warning

        public static void Warning(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Warning, null, message, null);
        }

        public static void Warning(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Warning, null, format, args);
        }

        public static void Warning(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Warning, exception, message, null);
        }

        public static void Warning(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Warning, exception, format, args);
        }

        #endregion

        #region error

        public static void Error(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Error, null, message, null);
        }

        public static void Error(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Error, null, format, args);
        }

        public static void Error(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Error, exception, message, null);
        }

        public static void Error(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Error, exception, format, args);
        }

        #endregion

        #region fatal

        public static void Fatal(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Fatal, null, message, null);
        }

        public static void Fatal(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Fatal, null, format, args);
        }

        public static void Fatal(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Fatal, exception, message, null);
        }
        
        public static void Fatal(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Fatal, exception, format, args);
        }

        #endregion

        private static void FilteredLog(ILogger logger, LogLevel level, Exception exception, string format, object[] objects)
        {
            if (logger.IsEnabled(level))
            {
                logger.Log(level, exception, format, objects);
            }
        }
    }
}
