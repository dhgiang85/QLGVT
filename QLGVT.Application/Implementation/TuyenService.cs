using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using QLGVT.Application.Interfaces;
using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Data.Entities;
using QLGVT.Data.Enums;
using QLGVT.Data.IRepositories;
using QLGVT.Infrastructure.Interfaces;
using QLGVT.Utilities.Dtos;

namespace QLGVT.Application.Implementation
{
    public class TuyenService: ITuyenService
    {
        private IUnitOfWork _unitOfWork;

        private ITuyenRepository _tuyenRepository;

        public TuyenService(IUnitOfWork unitOfWork,
            ITuyenRepository tuyenRepository)
        {
            _unitOfWork = unitOfWork;
            _tuyenRepository = tuyenRepository;
        }
        public void Add(TuyenViewModel tuyenVm)
        {
            var tuyen = Mapper.Map<TuyenViewModel, Tuyen>(tuyenVm);
            _tuyenRepository.Add(tuyen);
        }

        public void Update(TuyenViewModel tuyenVm)
        {
            var tuyen = Mapper.Map<TuyenViewModel, Tuyen>(tuyenVm); ;
            _tuyenRepository.Update(tuyen);
        }

        public void Delete(int id)
        {
            _tuyenRepository.Remove(id);
        }

        public TuyenViewModel GetById(int id)
        {
            return Mapper.Map<Tuyen, TuyenViewModel>(_tuyenRepository.FindById(id));
        }

        public List<TuyenViewModel> GetAll()
        {
            return _tuyenRepository.FindAll(x => x.Status == Status.Active).ProjectTo<TuyenViewModel>().ToList();
        }

        public PagedResult<TuyenViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _tuyenRepository.FindAll();
            //if (!string.IsNullOrEmpty(keyword))
            //    query = query.Where(x => x.Status==Status.Active);

            int totalRow = query.Count();

            //query = query.OrderByDescending(x => x.DateCreated)
            //    .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<TuyenViewModel>().ToList();
            data = data.OrderByDescending(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var paginationSet = new PagedResult<TuyenViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
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
