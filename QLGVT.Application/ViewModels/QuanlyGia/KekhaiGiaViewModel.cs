using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Data.Entities;
using QLGVT.Data.Enums;

namespace QLGVT.Application.ViewModels.QuanlyGia
{
    public class KekhaiGiaViewModel
    {
        //A. Sản lượng tính Giá Q (HK.Km)
        public int Id { get; set; }

        public decimal SLTG { get; set; }

        public decimal? SLTGRate { get; set; }

        //B. Chi phí sản xuất, kinh doanh(đồng/HK.Km)
        //I. Chi phí trực tiếp

        public decimal CPNL { get; set; }

        public decimal? CPNLRate { get; set; }

        public decimal CPNCTT { get; set; }

        public decimal? CPNCTTRate { get; set; }

        public decimal CPKHTB { get; set; }

        public decimal? CPKHTBRate { get; set; }

        public decimal CPSXKDDT { get; set; }

        public decimal? CPSXKDDTRate { get; set; }

        //II. Chi phí chung

        public decimal CPSXC { get; set; }

        public decimal? CPSXCRate { get; set; }

        public decimal CPTC { get; set; }

        public decimal? CPTCRate { get; set; }

        public decimal CPBH { get; set; }

        public decimal? CPBHRate { get; set; }

        public decimal CPQL { get; set; }

        public decimal? CPQLRate { get; set; }
                
        public decimal LoinhuanDukien { get; set; }

        public decimal GiathanhVe { get; set; }

        public string Note { get; set; }

        public int DangkyTuyenId { get; set; }

        public int? KekhaiGiaBaseId { get; set; }

        public virtual DangkyTuyenViewModel DangkyTuyen { get; set; }

        public KekhaiGiaStatus KekhaiGiaStatus { get; set; }

        public DateTime DateApplied { get; set; }

        public DateTime DateAccepted { get; set; }

    }
}
