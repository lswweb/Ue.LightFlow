namespace Ue.LightFlow.Commanding
{
    /// <summary>
    /// 命令执行结果
    /// </summary>
    public class CommandResult
    {
        public CommandResult() : this(0, "succeed") { }

        public CommandResult(int code,string message="error")
        {
            this.Code = code;
            this.Message = message;
        }

        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 成功/失败
        /// </summary>
        public bool IsSucceed
        {
            get { return this.Code == 0; }
        }
    }
}
