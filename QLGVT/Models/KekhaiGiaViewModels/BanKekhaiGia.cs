using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGVT.Models.KekhaiGiaViewModels
{
    public class BanKekhaiGia
    {
        //A. Sản lượng tính Giá Q (HK.Km)
        public int Id { get; set; }

        public decimal SLTG { get; set; }

        public decimal SLTGRate { get; set; }

        //B. Chi phí sản xuất, kinh doanh(đồng/HK.Km)
        //I. Chi phí trực tiếp

        public decimal CPNL { get; set; }

        public decimal CPNLRate { get; set; }

        public decimal CPNCTT { get; set; }

        public decimal CPNCTTRate { get; set; }

        public decimal CPKHTB { get; set; }

        public decimal CPKHTBRate { get; set; }

        public decimal CPSXKDDT { get; set; }

        public decimal CPSXKDDTRate { get; set; }

        public decimal TotalCPTT => CPNL + CPNCTT + CPKHTB + CPSXKDDT;

        //II. Chi phí chung

        public decimal CPSXC { get; set; }

        public decimal CPSXCRate { get; set; }

        public decimal CPTC { get; set; }

        public decimal CPTCRate { get; set; }

        public decimal CPBH { get; set; }

        public decimal CPBHRate { get; set; }

        public decimal CPQL { get; set; }

        public decimal CPQLRate { get; set; }

        public decimal TotalCPC => CPSXC + CPTC + CPBH + CPQL;

        public decimal Total => TotalCPTT + TotalCPC;

        public decimal PriceUnit => Total * DangkyTuyen.Tuyen.Khoangcach;

        public decimal LoiNhuanDukien { get; set; }

        public decimal PriceNotVAT => PriceUnit + LoiNhuanDukien;

        public int DangkyTuyenId { get; set; }

        public int KekhaiGiaBaseId { get; set; }

        public virtual DangkyTuyenViewModel DangkyTuyen { get; set; }

        public DateTime DateApplied { get; set; }

        public DateTime DateAccepted { get; set; }
    }
}
