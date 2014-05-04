﻿using System.Threading.Tasks;
using Ue.LightFlow.Messaging;

namespace Ue.LightFlow.Commanding
{
    public class DefaultCommandService : ICommandService
    {
        private readonly IProducer producer;
        private readonly CommandResultProcessor commandResultProcessor;

        public DefaultCommandService(IProducer producer,IConsumer commandExecutedConsumer)
        {
            this.producer = producer;
            this.commandResultProcessor = new CommandResultProcessor(commandExecutedConsumer);
        }

        public void Send(ICommand command)
        {
            this.producer.Send(new CommandMessage(command));
        }

        public Task<CommandResult> Execute(ICommand command)
        {
            var taskCompletionSource = new TaskCompletionSource<CommandResult>();

            this.commandResultProcessor.RegisterCommand(command, taskCompletionSource);

            this.producer.SendAsync(new CommandMessage(command)).ContinueWith(sendTask =>
            {
                var commandResult = sendTask.Result.Status
                    ? new CommandResult()
                    : new CommandResult(2);

                taskCompletionSource.TrySetResult(commandResult);
            });

            return taskCompletionSource.Task;
        }
    }
}
