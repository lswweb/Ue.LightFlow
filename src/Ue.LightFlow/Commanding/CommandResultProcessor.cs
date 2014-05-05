using System.Collections.Concurrent;
using System.Threading.Tasks;
using Ue.LightFlow.Messaging;
using Ue.LightFlow.Infrastructure;

namespace Ue.LightFlow.Commanding
{
    /// <summary>
    /// 命令结果处理器
    /// 从命令结果队列中接收命令处理结果
    /// </summary>
    //[Component(LifeStyle.Singleton)]
    public class CommandResultProcessor
    {
        private readonly IConsumer commandExecutedConsumer;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<CommandResult>> taskDictionary;
        private readonly WorkerQueue<CommandExecutedMessage> commandExecutedLocalWorker;

        public CommandResultProcessor(IConsumer commandExecutedConsumer)
        {
            this.commandExecutedConsumer = commandExecutedConsumer;
            this.taskDictionary = new ConcurrentDictionary<string, TaskCompletionSource<CommandResult>>();
            this.commandExecutedLocalWorker = new WorkerQueue<CommandExecutedMessage>(CommandExecutedMessageHandler);
        }

        public void RegisterCommand(ICommand command,TaskCompletionSource<CommandResult> taskCompletionSource)
        {
            this.taskDictionary.TryAdd(command.Id, taskCompletionSource);
        }

        public void Start()
        {
            this.commandExecutedConsumer.Start();
        }

        public void Stop()
        {
            this.commandExecutedConsumer.Shutdown();
        }

        /// <summary>
        /// 命令结果消息处理
        /// </summary>
        /// <param name="message"></param>
        private void CommandExecutedMessageHandler(CommandExecutedMessage message)
        {
            TaskCompletionSource<CommandResult> taskCompletionSource;
            if (this.taskDictionary.TryGetValue(message.CommandId, out taskCompletionSource))
            {
                taskCompletionSource.TrySetResult(new CommandResult());
            }
        }
    }
}
