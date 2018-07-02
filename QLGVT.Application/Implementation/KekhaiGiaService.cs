using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using QLGVT.Application.Interfaces;
using QLGVT.Application.ViewModels.QuanlyGia;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;
using QLGVT.Infrastructure.Interfaces;
using QLGVT.Utilities.Dtos;

namespace QLGVT.Application.Implementation
{
    public class KekhaiGiaService : IKekhaiGiaService
    {

        private IUnitOfWork _unitOfWork;
        private IKekhaiGiaRepository _kekhaiGiaRepository;


        public KekhaiGiaService(IKekhaiGiaRepository kekhaiGiaRepository,

            IUnitOfWork unitOfWork)
        {
            _kekhaiGiaRepository = kekhaiGiaRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(KekhaiGiaViewModel KKGVm)
        {
            var kkg = Mapper.Map<KekhaiGiaViewModel, KekhaiGia>(KKGVm);
            _kekhaiGiaRepository.Add(kkg);
        }

        public void Update(KekhaiGiaViewModel KKGVm)
        {
            var kkg = Mapper.Map<KekhaiGiaViewModel, KekhaiGia>(KKGVm);
            _kekhaiGiaRepository.Update(kkg);
        }

        public PagedResult<KekhaiGiaCalculatorViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _kekhaiGiaRepository.FindAll();
            //if (!string.IsNullOrEmpty(keyword))
            //    query = query.Where(x => x.Ten.Contains(keyword));

            int totalRow = query.Count();

            //query = query.OrderByDescending(x => x.DateCreated)
            //    .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<KekhaiGiaCalculatorViewModel>().ToList();
            data = data.OrderByDescending(x => x.DateApplied).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var paginationSet = new PagedResult<KekhaiGiaCalculatorViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public void Delete(int id)
        {
            _kekhaiGiaRepository.Remove(id);
        }

        public KekhaiGiaCalculatorViewModel GetById(int id)
        {
            return Mapper.Map<KekhaiGia, KekhaiGiaCalculatorViewModel>(_kekhaiGiaRepository.FindById(id));
        }

        public List<KekhaiGiaViewModel> GetAll()
        {
            throw new NotImplementedException();
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
