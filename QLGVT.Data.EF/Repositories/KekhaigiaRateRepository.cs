using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;

namespace QLGVT.Data.EF.Repositories
{
    public class KekhaiGiaRateRepository :EFRepository<KekhaiGiaRate, string>, IKekhaiGiaRateRepository
    {
        public KekhaiGiaRateRepository(AppDbContext context) : base(context)
        {
        }
    }
}
