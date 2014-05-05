using Ue.LightFlow.Configurations;

namespace Ue.LightFlow
{
    public sealed class AppContext
    {
        #region 构造及字段

        private readonly IConfiguration configuration;

        public AppContext(IConfiguration configuraion)
        {
            this.configuration = configuration;
        }

        #endregion

        public bool IsAlive { get; private set; }

        public void Start()
        {
            this.IsAlive = true;
            AppContext.currentContext = this;
        }

        public void Stop()
        {
            this.IsAlive = false;
            AppContext.currentContext = null;
        }

        #region IContainer

        //public T Resolve<T>() where T : class
        //{
        //    return this.container.Resolve<T>();
        //}

        //public bool IsRegistered(Type type)
        //{
        //    return this.container.IsRegistered(type);
        //}

        #endregion

        #region static field and method

        public static AppContext currentContext;

        public static AppContext GetContext()
        {
            if (AppContext.currentContext == null)
            {
                throw new LightFlowException("未启用AppContext");
            }

            return AppContext.currentContext;
        }

        #endregion
    }
}
