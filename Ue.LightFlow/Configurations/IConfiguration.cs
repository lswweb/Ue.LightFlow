using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ue.LightFlow.Configurations
{
    public interface IConfiguration
    {
        KeyValuePair<string, string> Components { get; }
    }
}
