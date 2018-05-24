using System;
using System.Collections.Generic;
using System.Text;
using QLGVT.Application.ViewModels.QuanLyDonVi;

namespace QLGVT.Application.Interfaces
{
    public interface IBenxeService
    {
        BenxeViewModel Add(BenxeViewModel benxeVm);

        void Update(BenxeViewModel benxeVm);
        
        BenxeViewModel GetById(int id);

        void Delete(int id);

        List<BenxeViewModel> GetAll();

        void ReOrder(int sourceId, int targetId);

        void Save();
    }
}
