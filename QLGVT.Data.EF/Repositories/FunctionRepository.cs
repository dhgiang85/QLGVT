using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;

namespace QLGVT.Data.EF.Repositories
{
    public class FunctionRepository : EFRepository<Function, string>, IFunctionRepository
    {
        public FunctionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
