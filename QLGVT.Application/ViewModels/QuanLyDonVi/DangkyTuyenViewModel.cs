using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Enums;

namespace QLGVT.Application.ViewModels.QuanLyDonVi
{
    public class DangkyTuyenViewModel
    {
        public int Id { get; set; }

        public int DonviVantaiId { get; set; }
        
        public int TuyenId { get; set; }

        public Status Status { get; set; }
    }
}
