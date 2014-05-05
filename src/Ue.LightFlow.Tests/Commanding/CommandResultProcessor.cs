using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ue.LightFlow.Commanding;
using Ue.LightFlow.Messaging;

namespace Ue.LightFlow.Tests.Commanding
{
    [TestClass]
    public class CommandResultProcessorTest
    {
        private IProducer producer;
        private IConsumer consumer;
        
        [TestInitialize]
        public void Initial()
        {
            this.producer = new DefaultProducer("testTopic");
        }

        [TestMethod]
        public void RegisterCommand()
        {
            var commandResultProcessor = new CommandResultProcessor(this.consumer);

            var command = new FakeCommand();
            var task = new TaskCompletionSource<CommandResult>();

            commandResultProcessor.RegisterCommand(command, task);
        }
    }
}
