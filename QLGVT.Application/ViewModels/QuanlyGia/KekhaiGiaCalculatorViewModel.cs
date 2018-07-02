using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLGVT.Application.ViewModels.QuanlyGia
{
    public class KekhaiGiaCalculatorViewModel
    {
        //A. Sản lượng tính Giá Q (HK.Km)
        public int Id { get; set; }

        public decimal SLTG { get; set; }

        public decimal? SLTGRate { get; set; }

        public CalculateStatus SLTGStatus { get; set; }

        //B. Chi phí sản xuất, kinh doanh(đồng/HK.Km)
        //I. Chi phí trực tiếp

        public decimal CPNL { get; set; }

        public decimal? CPNLRate { get; set; }

        public CalculateStatus CPNLStatus { get; set; }

        public decimal CPNCTT { get; set; }

        public decimal? CPNCTTRate { get; set; }

        public CalculateStatus CPNCTTStatus { get; set; }

        public decimal CPKHTB { get; set; }

        public decimal? CPKHTBRate { get; set; }

        public CalculateStatus CPKHTBStatus { get; set; }

        public decimal CPSXKDDT { get; set; }

        public decimal? CPSXKDDTRate { get; set; }

        public CalculateStatus CPSXKDDTStatus { get; set; }

        public decimal TotalCPTT => CPNL + CPNCTT + CPKHTB + CPSXKDDT;

        //II. Chi phí chung

        public decimal CPSXC { get; set; }

        public decimal? CPSXCRate { get; set; }

        public CalculateStatus CCPSXCStatus { get; set; }

        public decimal CPTC { get; set; }

        public decimal? CPTCRate { get; set; }

        public CalculateStatus CPTCStatus { get; set; }

        public decimal CPBH { get; set; }

        public decimal? CPBHRate { get; set; }

        public CalculateStatus CPBHStatus { get; set; }

        public decimal CPQL { get; set; }

        public decimal? CPQLRate { get; set; }

        public CalculateStatus CPQLStatus { get; set; }

        public decimal TotalCPC => CPSXC + CPTC + CPBH + CPQL;

        public decimal Total => TotalCPTT + TotalCPC;

        public decimal PriceUnit => Total * DangkyTuyen.Tuyen.Khoangcach;

        public decimal LoinhuanDukien { get; set; }

        //public decimal PriceNotVAT => PriceUnit + LoinhuanDukien;

        public decimal PriceNotVAT => GiathanhVe + LoinhuanDukien;

        public decimal VAT => PriceNotVAT * 0.1M;

        public decimal GiathanhVe { get; set; }

        public decimal GiaVeDukien => PriceNotVAT + VAT;

        public string Note { get; set; }

        public int DangkyTuyenId { get; set; }

        public int? KekhaiGiaBaseId { get; set; }
        public virtual DangkyTuyenViewModel DangkyTuyen { get; set; }

        public KekhaiGiaStatus KekhaiGiaStatus { get; set; }

        public DateTime DateApplied { get; set; }

        public DateTime DateAccepted { get; set; }
    }
}
