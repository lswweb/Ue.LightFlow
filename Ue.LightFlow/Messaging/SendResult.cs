namespace Ue.LightFlow.Messaging
{
    public class SendResult
    {
        public SendResult(bool status)
        {
            this.Status = status;
        }

        /// <summary>
        /// 状态： 成功/失败
        /// </summary>
        public bool Status { get; private set; }
    }
}
