using System;

namespace Ue.LightFlow.Infrastructure.Components
{
    /// <summary>
    /// Ioc服务
    /// </summary>
    public class ObjectContainer
    {
        /// <summary>
        /// 当前ioc容器
        /// </summary>
        public static IObjectContainer Current { get; private set; }

        /// <summary>
        /// 设置ioc容器
        /// </summary>
        /// <param name="container"></param>
        public static void SetContainer(IObjectContainer container)
        {
            Current = container;
        }

        /// <summary>
        /// 注册一个对象类型
        /// </summary>
        /// <param name="implementationType">对象类型</param>
        /// <param name="life">对象生命周期</param>
        public static void RegisterType(Type implementationType, LifeStyle life = LifeStyle.Singleton)
        {
            Current.RegisterType(implementationType, life);
        }

        /// <summary>
        /// 注册一个对象类型，并指定它为ServiceType的实现
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现对象类型</param>
        /// <param name="life">对象生命周期</param>
        public static void RegisterType(Type serviceType, Type implementationType, LifeStyle life = LifeStyle.Singleton)
        {
            Current.RegisterType(serviceType, implementationType, life);
        }

        /// <summary>
        /// 注册一个对象类型，并指定它为ServiceType的实现
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实现对象类型</typeparam>
        /// <param name="life">对象生命周期</param>
        public static void Register<TService, TImplementer>(LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            Current.Register<TService, TImplementer>(life);
        }

        /// <summary>
        /// 注册一个对象实例，并指定它为ServiceType的实现
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实现对象类型</typeparam>
        /// <param name="instance">对象实例</param>
        public static void RegisterInstance<TService, TImplementer>(TImplementer instance)
            where TService : class
            where TImplementer : class, TService
        {
            Current.RegisterInstance<TService, TImplementer>(instance);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>提供该服务的组件实例</returns>
        public static TService Resolve<TService>() where TService : class
        {
            return Current.Resolve<TService>();
        }

        /// <summary>
        /// </summary>
        /// <param name="serviceType">服务类型.</param>
        /// <returns>提供该服务的组件实例</returns>
        public static object Resolve(Type serviceType)
        {
            return Current.Resolve(serviceType);
        }
    }
}
