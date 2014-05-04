using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ue.LightFlow.Commanding
{
    /// <summary>
    /// 命令接口
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 全局标识Id
        /// </summary>
        string Id { get; set; }
    }
}
