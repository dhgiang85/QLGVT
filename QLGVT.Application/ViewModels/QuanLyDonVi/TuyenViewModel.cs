using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Entities;
using QLGVT.Data.Enums;

namespace QLGVT.Application.ViewModels.QuanLyDonVi
{
    public class TuyenViewModel
    {
        public int Id { get; set; }

        public int XuatphatId { get; set; }
        
        public int DiemdenId { get; set; }
        
        public BenxeViewModel Xuatphat { get; set; }

        public BenxeViewModel Diemden { get; set; }

        public int Khoangcach { get; set; }
        
        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

    }
}
