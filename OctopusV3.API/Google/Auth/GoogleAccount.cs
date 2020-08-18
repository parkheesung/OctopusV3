using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopusV3.API.Google
{
    public class GoogleAccount : AccountBase
    {
        public string SecretKey { get; set; } = string.Empty;

        public GoogleAccount() : base()
        {
        }
    }
}
