using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QLGVT.Data.Enums
{
    public enum KekhaiGiaStatus
    {
        [Description("Đã tiếp nhận")]
        Received = 0,
        [Description("Trả hồ sơ")]
        Denied = 1,
        [Description("Báo giá lại")]
        Reapply = 2,
        [Description("Thông báo giá")]
        Accepted = 3,
        [Description("Chấp nhận")]
        NewPriceAccepted = 4
    }
}
