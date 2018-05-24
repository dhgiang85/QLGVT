using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QLGVT.Data.Enums;

namespace QLGVT.Application.ViewModels.QuanLyDonVi
{
    public class BenxeViewModel
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Ten { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public int SortOrder { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }

}
