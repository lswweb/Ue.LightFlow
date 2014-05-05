namespace Ue.LightFlow.Commanding
{
    /// <summary>
    ///  命令执行器接口
    /// </summary>
    public interface ICommandHandler
    {
        void Handle(ICommand command);
    }
}
