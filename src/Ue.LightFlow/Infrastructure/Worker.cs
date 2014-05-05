using System;
using System.Collections.Concurrent;
using System.Threading;
using Ue.LightFlow.Infrastructure.Logging;

namespace Ue.LightFlow.Infrastructure
{
    /// <summary>
    /// 后台线程，重复执行某个特定的Action
    /// </summary>
    internal class Worker
    {
        private bool _stopped;
        private readonly Action action;
        private readonly Thread thread;
        private readonly ILogger logger;

        /// <summary>
        /// </summary>
        /// <param name="action">循环执行的特定委托方法</param>
        /// <param name="intervalMilliseconds">循环执行的时间间隔.</param>
        public Worker(Action action, int intervalMilliseconds = 0)
        {
            this.action = action;
            this.IntervalMilliseconds = intervalMilliseconds;
            this.thread = new Thread(Loop) { IsBackground = true };

            //_thread.Name = string.Format("Worker thread {0}", _thread.ManagedThreadId);
            //_logger = ObjectContainer.Resolve<ILoggerFactory>().Create(_thread.Name);
        }


        /// <summary>
        /// 指示当前线程的执行状态
        /// </summary>
        public bool IsAlive
        {
            get { return this.thread.IsAlive; }
        }

        public int IntervalMilliseconds { get; set; }

        /// <summary>
        /// 启动worker
        /// </summary>
        public void Start()
        {
            if (!thread.IsAlive)
            {
                thread.Start();
            }
        }

        /// <summary>
        /// 停止worker
        /// </summary>
        public void Stop()
        {
            _stopped = true;
        }

        /// <summary>
        /// 循环执行action方法
        /// </summary>
        private void Loop()
        {
            while (!_stopped)
            {
                try
                {
                    action();

                    if (IntervalMilliseconds > 0)
                    {
                        Thread.Sleep(IntervalMilliseconds);
                    }
                }
                catch (ThreadAbortException abortException)
                {
                    //_logger.Error("caught ThreadAbortException - resetting.", abortException);
                    Thread.ResetAbort();
                    //_logger.Info("ThreadAbortException resetted.");
                }
                catch (Exception ex)
                {
                    //_logger.Error("Exception raised when executing worker delegate.", ex);
                }
            }
        }
    }
}
