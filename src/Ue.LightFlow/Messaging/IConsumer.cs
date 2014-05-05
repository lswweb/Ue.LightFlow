using System;

namespace Ue.LightFlow.Messaging
{
    /// <summary>
    /// 队列消费者
    /// </summary>
    public interface IConsumer
    {
        /// <summary>
        /// 消息处理器
        /// </summary>
        Action<IMessage> MessageHandler { get; }

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
