using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OctopusV3.API
{
    public abstract class ApiHelperBase
    {
        public string ApplicationName { get; set; } = string.Empty;

        public IJsonHelper jsonHelper { get; set; }

        protected string Serialize(object target)
        {
            return jsonHelper.Serialize(target);
        }

        protected T Deserialize<T>(string json)
        {
            return jsonHelper.Deserialize<T>(json);
        }
    }
}
