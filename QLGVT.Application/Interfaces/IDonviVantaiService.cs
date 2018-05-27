using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Utilities.Dtos;

namespace QLGVT.Application.Interfaces
{
    public interface IDonviVantaiService : IDisposable
    {
        void Add(DonviVantaiViewModel donviVantai);

        Task<List<DonviVantaiViewModel>> GetAll(string filter);

        PagedResult<DonviVantaiViewModel> GetAllPaging(string keyword, int page, int pageSize);

        DonviVantaiViewModel GetById(int id);

        void Update(DonviVantaiViewModel donviVantai);

        List<DangkyTuyenViewModel> GetTuyens(int donvivantaiId);

        void AddTuyen(int donvivantaiId, List<DangkyTuyenViewModel> tuyens);

        void Delete(int id);

        void Save();


    }
}
