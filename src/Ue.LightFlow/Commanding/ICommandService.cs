using System.Threading.Tasks;

namespace Ue.LightFlow.Commanding
{
    /// <summary>
    /// 命令服务接口
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// 发送命令，不需要返回结果
        /// </summary>
        /// <param name="command"></param>
        void Send(ICommand command);

        /// <summary>
        /// 执行命令，可等待执行完毕得到返回结果
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<CommandResult> Execute(ICommand command);
    }
}
