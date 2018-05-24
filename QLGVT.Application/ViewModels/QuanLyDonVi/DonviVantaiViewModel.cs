using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QLGVT.Data.Enums;

namespace QLGVT.Application.ViewModels.QuanLyDonVi
{
    public class DonviVantaiViewModel
    {
        public int Id { get; set; }

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

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }
    }
}
