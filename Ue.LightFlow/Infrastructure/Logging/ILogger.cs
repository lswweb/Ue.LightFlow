using System;

namespace Ue.LightFlow.Infrastructure.Logging
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILogger
    {
        #region debug

        void Debug(object message);
        void DebugFormat(string format, params object[] args);
        void Debug(object message, Exception exception);

        #endregion

        #region info

        void Info(object message);
        void InfoFormat(string format, params object[] args);
        void Info(object message, Exception exception);

        #endregion

        #region error

        void Error(object message);
        void ErrorFormat(string format, params object[] args);
        void Error(object message, Exception exception);

        #endregion

        #region warn

        void Warn(object message);
        void WarnFormat(string format, params object[] args);
        void Warn(object message, Exception exception);

        #endregion

        #region fatal

        void Fatal(object message);
        void FatalFormat(string format, params object[] args);
        void Fatal(object message, Exception exception);

        #endregion
    }
}
