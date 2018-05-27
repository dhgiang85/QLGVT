using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using QLGVT.Data.Enums;
using QLGVT.Infrastructure.SharedKernel;

namespace QLGVT.Data.Entities
{
    [Table("DangkyTuyens")]
    public class DangkyTuyen : DomainEntity<int>
    {
        public DangkyTuyen()
        {

        }
        public DangkyTuyen(int id, int donviVantaiId, int tuyenId, Status status)
        {
            Id = id;
            DonviVantaiId = donviVantaiId;
            TuyenId = tuyenId;
            Status = status;
        }

        public DangkyTuyen(int donviVantaiId, int tuyenId, Status status)
        {
            DonviVantaiId = donviVantaiId;
            TuyenId = tuyenId;
            Status = status;
        }

        [Column(Order = 1)]
        public int DonviVantaiId { get; set; }

        [Column(Order = 2)]
        public int TuyenId { get; set; }

        [ForeignKey("DonviVantaiId")]
        public virtual DonviVantai DonviVantai { get; set; }

        [ForeignKey("TuyenId")]
        public virtual Tuyen Tuyen { get; set; }

        public Status Status { get; set; }
    }
}
