using System;
using System.Collections.Concurrent;

namespace Ue.LightFlow.Infrastructure
{
    /// <summary>
    /// 后台线程，自动读取队列内容，并进行处理
    /// </summary>
    internal class WorkerQueue<T>
    {
        private readonly Worker worker;
        private readonly BlockingCollection<T> queue;

        public WorkerQueue(Action<T> handler, ConcurrentQueue<T> queue = null)
        {
            this.queue = new BlockingCollection<T>(queue ?? new ConcurrentQueue<T>());

            this.worker = new Worker(() =>
            {
                T value;
                if (this.queue.TryTake(out value))
                {
                    handler(value);
                }
            });

        }

        public bool TryAdd(T item)
        {
            return this.queue.TryAdd(item);
        }

        public void Add(T item)
        {
            this.queue.Add(item);
        }

        public void Start()
        {
            this.worker.Start();
        }

        public void Stop()
        {
            this.worker.Stop();
        }
    }
}
