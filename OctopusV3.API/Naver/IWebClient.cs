using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.API
{
    public interface IWebClient
    {
        string DownloadString(string url);
    }
}
