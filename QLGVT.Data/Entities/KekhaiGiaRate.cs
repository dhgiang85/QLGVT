using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Enums;
using QLGVT.Data.Interfaces;
using QLGVT.Infrastructure.SharedKernel;

namespace QLGVT.Data.Entities
{
    public class KekhaiGiaRate : DomainEntity<string>, ISwitchable, IDateTracking
    {
        //A. Sản lượng tính Giá Q (HK.Km)

        public decimal SLTGRate { get; set; }
        
        //B. Chi phí sản xuất, kinh doanh(đồng/HK.Km)
        //I. Chi phí trực tiếp
        
        public decimal CPNLRate { get; set; }

        public decimal CPNCTTRate { get; set; }

        public decimal CPKHTBRate { get; set; }

        public decimal CPSXKDDTRate { get; set; }

        public decimal CPSXCTRate { get; set; }
        
        public decimal CPTCRate { get; set; }

        public decimal CPBHRate { get; set; }
        
        public decimal CPQLRate { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
