using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ue.LightFlow.Messaging;
using Ue.LightFlow.Messaging.Impl;

namespace Ue.LightFlow.Tests.Messaging
{
    [TestClass]
    public class TopicTests
    {
        [TestMethod]
        public void AfterCreated()
        {
            var topic1 = new Topic("test1");

            Assert.AreEqual("test1", topic1.Name);

            Assert.AreEqual(0, topic1.Subscribes.Count());
        }

        [TestMethod]
        public void RegisterSubscribe()
        {
            var topic1 = new Topic("test1");
            Action<IMessage> messageHandler = message => { };

            topic1.Subscribe(messageHandler);

            Assert.AreEqual(1, topic1.Subscribes.Count());
        }

        [TestMethod]
        public void DuplicateRegisterSubscribes()
        {
            var topic1 = new Topic("test1");
            Action<IMessage> messageHandler = message => { };

            var tasks = new List<Task>();
            for (var i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => topic1.Subscribe(messageHandler)));
            }

            Task.WaitAll(tasks.ToArray());

            Assert.AreEqual(1, topic1.Subscribes.Count());
        }

        [TestMethod]
        public void Distribution()
        {
            var topic1 = new Topic("test1");

            int resultCount1 = 0, 
                resultCount2 = 0, 
                resultCount3=0;

            topic1.Subscribe(message=>resultCount1++);
            topic1.Subscribe(message => resultCount2++);
            topic1.Subscribe(message => resultCount3++);

            var count = 100;
            for (var i = 0; i < count; i++)
            {
                topic1.Send(new FakeMessage());
            }

            System.Threading.Thread.Sleep(10);

            Assert.AreEqual(count, resultCount1);
            Assert.AreEqual(count, resultCount2);
            Assert.AreEqual(count, resultCount3);
        }
    }
}
