using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.Core
{
    public interface IEntity
    {
        string TableName { get; set; }
        string TargetColumn { get; set; }
    }
}
