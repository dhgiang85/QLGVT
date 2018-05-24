using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;

namespace QLGVT.Data.EF.Repositories
{
    public class BenxeRepository : EFRepository<Benxe, int>, IBenxeRepository
    {
        public BenxeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
