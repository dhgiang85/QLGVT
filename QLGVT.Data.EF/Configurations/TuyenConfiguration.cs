using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLGVT.Data.EF.Extensions;
using QLGVT.Data.Entities;

namespace QLGVT.Data.EF.Configurations
{
    public class TuyenConfiguration : DbEntityConfiguration<Tuyen>
    {
        public override void Configure(EntityTypeBuilder<Tuyen> entity)
        {
            entity.HasOne(p => p.Diemden)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.Xuatphat)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
