using System.Threading.Tasks;

namespace Ue.LightFlow.Messaging.Impl
{
    public class DefaultProducer : IProducer
    {
        private readonly Topic topic;

        public DefaultProducer(string topicName)
        {
            this.topic= TopicManager.Instance.RegisterTopic(topicName);
        }

        public SendResult Send(IMessage message)
        {
            this.topic.Send(message);

            return new SendResult(true);
        }

        public Task<SendResult> SendAsync(IMessage message)
        {
            return new Task<SendResult>(() => this.Send(message));
        }

        public void Start()
        {
        }

        public void Shutdown()
        {
        }
    }
}
