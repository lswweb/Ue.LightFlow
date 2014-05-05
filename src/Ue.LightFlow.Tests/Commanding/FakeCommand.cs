using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ue.LightFlow.Commanding;

namespace Ue.LightFlow.Tests.Commanding
{
    public class FakeCommand  : ICommand
    {
        public FakeCommand()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}
