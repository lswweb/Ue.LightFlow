using System;

namespace Ue.LightFlow.Infrastructure.Components
{
    /// <summary>
    /// 标识对象是一个组件
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentAttribute : Attribute
    {
        public ComponentAttribute(LifeStyle lifeStyle= LifeStyle.Transient)
        {
            this.LifeStyle = lifeStyle;
        }

        /// <summary>
        /// 组件生命周期
        /// </summary>
        public LifeStyle LifeStyle { get; private set; }
    }
}
