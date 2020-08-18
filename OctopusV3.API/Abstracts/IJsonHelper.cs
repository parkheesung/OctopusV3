using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.API
{
    public interface IJsonHelper
    {
        string Serialize(object target);

        T Deserialize<T>(string json);
    }
}
