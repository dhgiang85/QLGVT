using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;

namespace QLGVT.Data.EF.Repositories
{
    public class DangkyTuyenRepository : EFRepository<DangkyTuyen, int>, IDangkyTuyenRepository
    {
        public DangkyTuyenRepository(AppDbContext context) : base(context)
        {
        }
    }
}
