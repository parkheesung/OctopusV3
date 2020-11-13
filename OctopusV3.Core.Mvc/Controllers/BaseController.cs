using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OctopusV3.Core.Mvc
{
    public class BaseController : Controller
    {
        protected Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        public BaseController() : base()
        {
            GlobalSite.Current.Controller = this;
            this.Headers.Add("p3p", "CP=\"NOI DEVa TAIa OUR BUS UNI\"");
            this.Initialize();
        }

        protected virtual void Initialize()
        {
            if (GlobalSite.Current.Context != null && Headers.Count > 0)
            {
                foreach(var header in this.Headers)
                {
                    GlobalSite.Current.Context.Response.Headers.Add(header.Key, header.Value);
                }
            }
        }
    }
}
