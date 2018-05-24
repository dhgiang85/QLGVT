using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;

namespace QLGVT.Data.EF.Repositories
{
    public class TuyenRepository:EFRepository<Tuyen, int>, ITuyenRepository
    {
        public TuyenRepository(AppDbContext context) : base(context)
        {
        }
    }
}
