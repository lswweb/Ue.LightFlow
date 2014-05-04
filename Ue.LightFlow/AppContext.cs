using System;
using System.Linq;

namespace Ue.LightFlow
{
    public sealed class AppContext
    {
        #region 构造及字段

        //private IContainer container;

        //public AppContext(IContainer container)
        //    : this(container, ConfigurationManager.AppSettings["ue_cqrs_settigs_path"]) { }

        //public AppContext(IContainer container, string configPath)
        //    : this(container, ConfigurationFactory.Build(configPath)) { }

        //public AppContext(IContainer container, IConfiguration configuration)
        //{
        //    if (configuration == null)
        //    {
        //        throw new ArgumentNullException("configuration");
        //    }

        //    this.container = new DefaultContainer(configuration,container);
        //}

        #endregion

        public bool IsStart { get; private set; }

        public void Start()
        {
            this.IsStart = true;
            AppContext.currentContext = this;
        }

        public void Stop()
        {
            this.IsStart = false;
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
