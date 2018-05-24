using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QLGVT.Data.Enums
{
    public enum LHKinhDoanh
    {
        [Description("Theo tuyến cố định")]
        TuyenCodinh = 0,
        [Description("Taxi")]
        Taxi = 1,
        [Description("Xe Buýt")]
        Buyt = 2
    }
}
