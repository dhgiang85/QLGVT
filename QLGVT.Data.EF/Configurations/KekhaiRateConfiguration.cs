using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLGVT.Data.EF.Extensions;
using QLGVT.Data.Entities;

namespace QLGVT.Data.EF.Configurations
{
    class KekhaiRateConfiguration : DbEntityConfiguration<KekhaiGiaRate>
    {
        public override void Configure(EntityTypeBuilder<KekhaiGiaRate> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired()
                .HasColumnType("varchar(128)");
        }
    }
}
