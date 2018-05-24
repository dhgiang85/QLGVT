using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using QLGVT.Data.Enums;
using QLGVT.Data.Interfaces;
using QLGVT.Infrastructure.SharedKernel;

namespace QLGVT.Data.Entities
{
    [Table("DonviVantais")]
    public class DonviVantai : DomainEntity<int>, ISwitchable, IHasSeoMetaData, IDateTracking
    {
        public DonviVantai()
        {
            DangkyTuyens = new List<DangkyTuyen>();
        }
        public DonviVantai(string ten, string diachi, string gpKinhdoanh,
            LHKinhDoanh lhKinhdoanh, Status status, string seoPageTitle,
            string seoAlias, string seoMetaKeyword,
            string seoMetaDescription)
        {    
            Ten = ten;
            Diachi = diachi;
            GPKinhdoanh = gpKinhdoanh;
            LHKinhdoanh = lhKinhdoanh;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
        }
        public DonviVantai(int id, string ten, string diachi, string gpKinhdoanh, 
            LHKinhDoanh lhKinhdoanh, Status status, string seoPageTitle,
            string seoAlias, string seoMetaKeyword,
            string seoMetaDescription)
        {
            Id = id;
            Ten = ten;
            Diachi = diachi;
            GPKinhdoanh = gpKinhdoanh;
            LHKinhdoanh = lhKinhdoanh;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
        }

        [StringLength(255)]
        [Required]
        public string Ten { get; set; }

        [StringLength(255)]
        [Required]
        public string Diachi { get; set; }

        [StringLength(50)]
        [Required]
        public string GPKinhdoanh { get; set; }

        [Required]
        public LHKinhDoanh LHKinhdoanh { get; set; }
        
        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public virtual ICollection<DangkyTuyen> DangkyTuyens { set; get; }

    }
}
