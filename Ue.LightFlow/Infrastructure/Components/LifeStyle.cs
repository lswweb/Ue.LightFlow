using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ue.LightFlow.Infrastructure.Components
{
    public enum LifeStyle
    {
        /// <summary>
        ///常规组件
        /// </summary>
        Transient,
        
        /// <summary>
        /// 单例组件
        /// </summary>
        Singleton
    }
}
