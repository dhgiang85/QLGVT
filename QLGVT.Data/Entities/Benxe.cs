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
    [Table("Benxes")]
    public class Benxe : DomainEntity<int>, ISwitchable, ISortable, IDateTracking
    {
        public Benxe()
        {
          
        }
        public Benxe(string ten, string description,int sortOrder, Status status)
        {
            Ten = ten;
            Description = description;
            SortOrder = sortOrder;
            Status = status;
        }
        

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
