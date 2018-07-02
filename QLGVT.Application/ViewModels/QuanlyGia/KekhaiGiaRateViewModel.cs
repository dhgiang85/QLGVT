using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Enums;

namespace QLGVT.Application.ViewModels.QuanlyGia
{
    public class KekhaiGiaRateViewModel
    {
        public string Id { get; set; }

        public decimal SLTGRate { get; set; }

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
