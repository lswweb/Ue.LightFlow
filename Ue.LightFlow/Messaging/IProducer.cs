using System.Threading.Tasks;

namespace Ue.LightFlow.Messaging
{
    /// <summary>
    /// 队列生产者
    /// </summary>
    public interface IProducer
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        SendResult Send(IMessage message);

        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<SendResult> SendAsync(IMessage message);

        /// <summary>
        /// 启动
        /// </summary>
        void Start();

        /// <summary>
        /// 关闭
        /// </summary>
        void Shutdown();
    }
}
