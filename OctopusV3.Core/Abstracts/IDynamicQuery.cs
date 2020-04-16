using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.Core
{
    public interface IDynamicQuery : IDynamicQueryBase
    {
        int CurPage { get; set; }
        int PageSize { get; set; }

    }
}
