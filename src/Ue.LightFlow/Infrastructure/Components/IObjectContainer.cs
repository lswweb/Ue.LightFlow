using System;

namespace Ue.LightFlow.Infrastructure.Components
{
    /// <summary>
    /// Ioc接口
    /// </summary>
    public interface IObjectContainer
    {
        /// <summary>
        /// 注册一个对象类型
        /// </summary>
        /// <param name="implementationType">对象类型</param>
        /// <param name="life">对象生命周期</param>
        void RegisterType(Type implementationType, LifeStyle life = LifeStyle.Singleton);

        /// <summary>
        /// 注册一个对象类型，并指定它为ServiceType的实现
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现对象类型</param>
        /// <param name="life">对象生命周期</param>
        void RegisterType(Type serviceType, Type implementationType, LifeStyle life = LifeStyle.Singleton);

        /// <summary>
        /// 注册一个对象类型，并指定它为ServiceType的实现
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实现对象类型</typeparam>
        /// <param name="life">对象生命周期</param>
        void Register<TService, TImplementer>(LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService;

        /// <summary>
        /// 注册一个对象实例，并指定它为ServiceType的实现
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实现对象类型</typeparam>
        /// <param name="instance">对象实例</param>
        void RegisterInstance<TService, TImplementer>(TImplementer instance)
            where TService : class
            where TImplementer : class, TService;

        /// <summary>
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>提供该服务的组件实例</returns>
        TService Resolve<TService>() where TService : class;

        /// <summary>
        /// </summary>
        /// <param name="serviceType">服务类型.</param>
        /// <returns>提供该服务的组件实例</returns>
        object Resolve(Type serviceType);
    }
}
