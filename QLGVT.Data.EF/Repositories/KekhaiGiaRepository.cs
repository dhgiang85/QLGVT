using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;

namespace QLGVT.Data.EF.Repositories
{
    public class KekhaiGiaRepository : EFRepository<KekhaiGia, int>, IKekhaiGiaRepository
    {
        public KekhaiGiaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
