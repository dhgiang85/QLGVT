using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QLGVT.Data.Enums;
using QLGVT.Data.Interfaces;
using QLGVT.Infrastructure.SharedKernel;

namespace QLGVT.Data.Entities
{
    [Table("KekhaiGias")]
    public class KekhaiGia : DomainEntity<int>, IDateTracking
    {

        public KekhaiGia()
        {
            DangkyTuyen = new DangkyTuyen();
        }
        public KekhaiGia( decimal sltg, decimal? sltgrate, 
            decimal cpnl, decimal? cpnlrate,
            decimal cpnctt, decimal? cpncttrate,
            decimal cpkhtb, decimal? cpkhtbrate,
            decimal cpsxkddt, decimal? cpsxkddtrate, 
            decimal cpsxc, decimal? cpsxcrate,
            decimal cptc, decimal? cptcrate, 
            decimal cpbh, decimal? cpbhrate,
            decimal cpql, decimal? cpqlrate,
            decimal loinhuandukien, decimal giathanhve, string note, int dangkytuyenid,
            int? kekhaiGiaBaseId,
            KekhaiGiaStatus kekhaigiastatus
            )
        {
            SLTG = sltg; SLTGRate = sltgrate;
            CPNL = cpnl; CPNLRate = cpnlrate; 
            CPNCTT = cpnctt; CPNCTTRate =  cpncttrate;
            CPKHTB = cpkhtb; CPKHTBRate = cpkhtbrate; 
            CPSXKDDT = cpsxkddt; CPSXKDDTRate = cpsxkddtrate; 
            CPSXC =  cpsxc; CPSXCRate = cpsxcrate; 
            CPTC = cptc; CPTCRate = cptcrate; 
            CPBH = cpbh; CPBHRate = cpbhrate; 
            CPQL = cpql; CPQLRate = cpqlrate; 
            LoinhuanDukien = loinhuandukien;
            GiathanhVe = giathanhve;
            Note = note;
            DangkyTuyenId = dangkytuyenid;
            KekhaiGiaBaseId = kekhaiGiaBaseId;
            KekhaiGiaStatus = kekhaigiastatus;
        }
        //A. Sản lượng tính Giá Q (HK.Km)

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

        [ForeignKey("DangkyTuyenId")]
        public virtual DangkyTuyen DangkyTuyen { get; set; }

        public KekhaiGiaStatus KekhaiGiaStatus { get; set; }

        public DateTime DateApplied { get; set; }

        public DateTime DateAccepted { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

       
    }
}
