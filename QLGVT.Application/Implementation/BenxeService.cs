using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using QLGVT.Application.Interfaces;
using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;
using QLGVT.Infrastructure.Interfaces;

namespace QLGVT.Application.Implementation
{
    public class BenxeService : IBenxeService
    {
        private IUnitOfWork _unitOfWork;

        private IBenxeRepository _benxeRepository;

        public BenxeService(IUnitOfWork unitOfWork, IBenxeRepository benxeRepository)
        {
            _unitOfWork = unitOfWork;
            _benxeRepository = benxeRepository;
        }
        public BenxeViewModel Add(BenxeViewModel benxeVm)
        {
            var benxe = Mapper.Map<BenxeViewModel, Benxe>(benxeVm);
             _benxeRepository.Add(benxe);
            return benxeVm;
        }

        public void Update(BenxeViewModel benxeVm)
        {
            var benxe = Mapper.Map<BenxeViewModel, Benxe>(benxeVm);
            _benxeRepository.Update(benxe);
        }

        public BenxeViewModel GetById(int id)
        {
           return Mapper.Map<Benxe, BenxeViewModel>(_benxeRepository.FindById(id));

        }

        public void Delete(int id)
        {
           _benxeRepository.Remove(id);
        }

        public List<BenxeViewModel> GetAll()
        {
            return _benxeRepository.FindAll().OrderBy(x=>x.SortOrder)
                .ProjectTo<BenxeViewModel>().ToList();
        }

        public void ReOrder(int sourceId, int targetId)
        {
            var source = _benxeRepository.FindById(sourceId);
            var target = _benxeRepository.FindById(targetId);
            int tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;
            _benxeRepository.Update(source);
            _benxeRepository.Update(target);
        }
       

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
