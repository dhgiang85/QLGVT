using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Enums;

namespace QLGVT.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
