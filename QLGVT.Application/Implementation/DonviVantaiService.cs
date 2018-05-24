using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DonviVantaiService : IDonviVantaiService
    {

        private IUnitOfWork _unitOfWork;
        private IDonviVantaiReposiory _donviVantaiReposiory;
        
        public DonviVantaiService(IDonviVantaiReposiory donviVantaiReposiory,
            IUnitOfWork unitOfWork)
        {
            _donviVantaiReposiory = donviVantaiReposiory;
            _unitOfWork = unitOfWork;
        }


        public void Add(DonviVantaiViewModel donviVantaiVm)
        {
            var donviVantai = Mapper.Map<DonviVantaiViewModel, DonviVantai>(donviVantaiVm);
            _donviVantaiReposiory.Add(donviVantai);
        }

        public void Update(DonviVantaiViewModel donviVantaiVm)
        {
            var donviVantai = Mapper.Map<DonviVantaiViewModel, DonviVantai>(donviVantaiVm);
            _donviVantaiReposiory.Update(donviVantai);
        }

        public void Delete(int id)
        {
            _donviVantaiReposiory.Remove(id);
        }

        public PagedResult<DonviVantaiViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _donviVantaiReposiory.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Ten.Contains(keyword));

            int totalRow = query.Count();

            //query = query.OrderByDescending(x => x.DateCreated)
            //    .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<DonviVantaiViewModel>().ToList();
            data = data.OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var paginationSet = new PagedResult<DonviVantaiViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public DonviVantaiViewModel GetById(int id)
        {
            return Mapper.Map<DonviVantai, DonviVantaiViewModel>(_donviVantaiReposiory.FindById(id));
        }

        public Task<List<DonviVantaiViewModel>> GetAll(string filter)
        {
            return _donviVantaiReposiory.FindAll(x => x.Status == Status.Active).ProjectTo<DonviVantaiViewModel>().ToListAsync();

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
