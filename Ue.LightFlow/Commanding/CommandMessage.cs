using Ue.LightFlow.Messaging;

namespace Ue.LightFlow.Commanding
{
    public class CommandMessage : IMessage
    {
        public CommandMessage(ICommand command)
        {
            this.Command = command;
        }

        public ICommand Command { get; private set; }
    }
}
