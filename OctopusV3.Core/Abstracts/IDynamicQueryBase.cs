using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.Core
{
    public interface IDynamicQueryBase
    {
        string OrderBy { get; set; }

        string URL { get; set; }

        int LastPage { get; }

        int TotalPageCount { get; set; }

        int SequenceNumber { get; }

        string GetURL(int pageNum);


        List<int> GetPaging();

        int PreviousPage { get; }


        int NextPage { get; }

        string Serialize();

        string WhereString { get; set; }

    }
}
