using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using Ue.LightFlow.Infrastructure;

namespace Ue.LightFlow.Messaging
{
    /// <summary>
    /// 主题
    /// </summary>
    public class Topic
    {
        private readonly string name;
        private readonly IList<Action<IMessage>> subscribes;
        private readonly WorkerQueue<IMessage> workQueue;
        private readonly ReaderWriterLockSlim lockSlim;

        public Topic(string name)
        {
            name.ArgumentNullException("name");

            this.name = name;
            this.subscribes = new List<Action<IMessage>>();
            this.workQueue = new WorkerQueue<IMessage>(DistributionHandler);
            this.lockSlim = new ReaderWriterLockSlim();

            this.workQueue.Start();
        }

        /// <summary>
        /// 主题名称
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        public void Send(IMessage message)
        {
            this.workQueue.Add(message);
        }

        /// <summary>
        /// 主题订阅集合
        /// </summary>
        public IEnumerable<Action<IMessage>> Subscribes
        {
            get { return this.subscribes; }
        }

        /// <summary>
        /// 订阅主题
        /// </summary>
        /// <param name="action"></param>
        public void Subscribe(Action<IMessage> action)
        {
            this.lockSlim.EnterWriteLock();

            if (!this.subscribes.Contains(action))
            {
                this.subscribes.Add(action);
            }

            this.lockSlim.ExitWriteLock();
        }

        /// <summary>
        /// 移除订阅
        /// </summary>
        /// <param name="action"></param>
        public void RemoveSubscribe(Action<IMessage> action)
        {
            this.lockSlim.EnterWriteLock();

            this.subscribes.Remove(action);

            this.lockSlim.ExitWriteLock();
        }

        private void DistributionHandler(IMessage message)
        {
            foreach (var item in subscribes)
            {
                item(message);
            }
        }
    }
}
