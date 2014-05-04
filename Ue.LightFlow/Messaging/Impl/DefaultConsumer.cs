using System;

namespace Ue.LightFlow.Messaging.Impl
{
    /// <summary>
    /// 消费者
    /// </summary>
    public class DefaultConsumer : IConsumer
    {
        private readonly string topicName;

        public DefaultConsumer(string topicName, Action<IMessage> messageHandler)
        {
            this.MessageHandler = messageHandler;
            this.topicName = topicName;
        }

        public Action<IMessage> MessageHandler { get; private set; }

        public void Start()
        {
            TopicManager.Instance.Subscribe(topicName, this.MessageHandler);
        }

        public void Shutdown()
        {
            TopicManager.Instance.RemoveSubscribe(topicName, this.MessageHandler);            
        }
    }
}
