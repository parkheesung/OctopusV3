using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.Core.Mvc
{
    public class GlobalSite
    {
        private static readonly Lazy<GlobalSite> lazy = new Lazy<GlobalSite>(() => new GlobalSite());
        public static GlobalSite Current { get { return lazy.Value; } }

        public BaseController Controller { get; set; }

        public HttpContext Context { get; set; }

        public GlobalSite()
        {
        }

        public HttpResponse Response
        {
            get
            {
                return this.Controller.Response;
            }
        }

        public HttpRequest Request
        {
            get
            {
                return this.Controller.Request;
            }
        }
    }
}
