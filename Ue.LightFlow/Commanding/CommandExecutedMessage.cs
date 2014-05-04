using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ue.LightFlow.Messaging;

namespace Ue.LightFlow.Commanding
{
    /// <summary>
    /// 命令执行结果消息
    /// </summary>
    [Serializable]
    public class CommandExecutedMessage : IMessage
    {
        public string CommandId { get; set; }
    }
}
