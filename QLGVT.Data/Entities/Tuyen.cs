using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using QLGVT.Data.Enums;
using QLGVT.Data.Interfaces;
using QLGVT.Infrastructure.SharedKernel;

namespace QLGVT.Data.Entities
{
    [Table("Tuyens")]
    public class Tuyen : DomainEntity<int>, ISwitchable, IDateTracking
    {
        public Tuyen()
        {

        }
        public Tuyen(int xuatphatId, int diemdenId, int khoangcach, Status status)
        {
            XuatphatId = xuatphatId;
            DiemdenId = diemdenId;
            Khoangcach = khoangcach;
            Status = status;
        }
        [Column(Order = 1)]
        public int XuatphatId { get; set; }

        [Column(Order = 2)]
        public int DiemdenId { get; set; }

        [ForeignKey("XuatphatId")]
        public virtual Benxe Xuatphat { get; set; }

        [ForeignKey("DiemdenId")]
        public virtual Benxe Diemden { get; set; }

        public int Khoangcach { get; set; }
        
        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

    }
}
