using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.Core
{
    public interface ISubDynamicQuery : IDynamicQueryBase
    {
        int SubCurPage { get; set; }
        int SubPageSize { get; set; }


    }
}
