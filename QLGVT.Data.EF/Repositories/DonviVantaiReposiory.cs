using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;

namespace QLGVT.Data.EF.Repositories
{
    public class DonviVantaiReposiory : EFRepository<DonviVantai, int>, IDonviVantaiReposiory
    {
        public DonviVantaiReposiory(AppDbContext context) : base(context)
        {
        }
    }
}
