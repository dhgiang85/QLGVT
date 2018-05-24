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
