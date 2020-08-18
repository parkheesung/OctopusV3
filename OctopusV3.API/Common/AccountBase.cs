using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopusV3.API
{
    public abstract class AccountBase
    {
        public string AccountID { get; set; } = string.Empty;

        public string AccountPWD { get; set; } = string.Empty;
    }
}
