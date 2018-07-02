using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QLGVT.Data.Enums
{
    public enum CalculateStatus
    {
        [Description("Chưa tính toán")]
        NonCal = 0,
        [Description("Quá tỷ lệ")]
        Overrate = 1,
        [Description("Trong tỷ lệ")]
        Ok = 2
    }
}
