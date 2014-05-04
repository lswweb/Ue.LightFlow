using System;
using System.Collections.Concurrent;

namespace Ue.LightFlow.Messaging.Impl
{
    public class TopicManager
    {
        #region static single

        private static class QueueManagerHolder
        {
            public static readonly TopicManager instance = new TopicManager();
        }

        public static TopicManager Instance
        {
            get { return QueueManagerHolder.instance; }
        }

        #endregion


        public readonly ConcurrentDictionary<string, Topic> topicDictionary;

        private TopicManager()
        {
            this.topicDictionary = new ConcurrentDictionary<string, Topic>();
        }

        /// <summary>
        /// 获取主题
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Topic GetTopic(string name)
        {
            Topic topic;
            if (!this.topicDictionary.TryGetValue(name, out topic))
            {
                throw new ArgumentOutOfRangeException(string.Format("TopicManager中不存在名为\"{0}\"的topic", name));
            }

            return topic;
        }

        /// <summary>
        /// 注册主题
        /// </summary>
        /// <param name="name"></param>
        public Topic RegisterTopic(string name)
        {
            name.ArgumentNullException("name");

            var topic=new Topic(name);
            if (!this.topicDictionary.TryAdd(name, topic))
            {
                throw new ArgumentException(string.Format("注册topc失败，请检测是否已经存中名为\"{0}\"的主题。", name));                
            }

            return topic;
        }

        /// <summary>
        /// 订阅主题
        /// </summary>
        /// <param name="topicName">主题名称</param>
        /// <param name="action">订阅通知委托方法</param>
        public void Subscribe(string topicName, Action<IMessage> action)
        {
            topicName.ArgumentNullException("topicName");
            action.ArgumentNullException("action");

            this.GetTopic(topicName).Subscribe(action);
        }

        /// <summary>
        /// 移除订阅
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="action"></param>
        public void RemoveSubscribe(string topicName, Action<IMessage> action)
        {
            topicName.ArgumentNullException("topicName");
            action.ArgumentNullException("action");

            this.GetTopic(topicName).RemoveSubscribe(action);
        }
    }
}
