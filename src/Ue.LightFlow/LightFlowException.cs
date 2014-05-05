using System;

namespace Ue.LightFlow
{
    /// <summary>
    /// LightFlow系统异常
    /// </summary>
    [Serializable]
    public class LightFlowException : Exception
    {
        public LightFlowException() { }
 
        public LightFlowException(string message) : base(message) { }

        public LightFlowException(string message, Exception innerException) : base(message, innerException) { }

        public LightFlowException(string message, params object[] args) : base(string.Format(message, args)) { }
    }
}
