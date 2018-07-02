using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Application.ViewModels.QuanlyGia;
using QLGVT.Utilities.Dtos;

namespace QLGVT.Application.Interfaces
{
    public interface IKekhaiGiaService : IDisposable
    {
        void Add(KekhaiGiaViewModel KKGVm);

        void Update(KekhaiGiaViewModel KKGVm);

        PagedResult<KekhaiGiaCalculatorViewModel> GetAllPaging(string keyword, int page, int pageSize);

        KekhaiGiaCalculatorViewModel GetById(int id);
           
        void Delete(int id);

        List<KekhaiGiaViewModel> GetAll();

      

        void Save();

    }
}
