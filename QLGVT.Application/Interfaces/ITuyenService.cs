using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Utilities.Dtos;

namespace QLGVT.Application.Interfaces
{
    public interface ITuyenService
    {
        void Add(TuyenViewModel tuyenVm);

        List<TuyenViewModel> GetAll();

        PagedResult<TuyenViewModel> GetAllPaging(string keyword, int page, int pageSize);

        TuyenViewModel GetById(int id);

        void Update(TuyenViewModel tuyenVm);

        void Delete(int id);

        void Save();
    }
}
