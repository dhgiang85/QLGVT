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
using QLGVT.Application.ViewModels.QuanlyGia;
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
        private IDangkyTuyenRepository _dangkyTuyenRepository;
        private IKekhaiGiaRepository _kekhaiGiaRepository;


        public DonviVantaiService(IDonviVantaiReposiory donviVantaiReposiory,
            IDangkyTuyenRepository dangkyTuyenRepository,
            IKekhaiGiaRepository kekhaiGiaRepository,
            IUnitOfWork unitOfWork)
        {
            _donviVantaiReposiory = donviVantaiReposiory;
            _kekhaiGiaRepository = kekhaiGiaRepository;
            _dangkyTuyenRepository = dangkyTuyenRepository;


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

        public List<DangkyTuyenViewModel> GetTuyens(int donvivantaiId)
        {
            return _dangkyTuyenRepository.FindAll(x => x.DonviVantaiId == donvivantaiId)
                .ProjectTo<DangkyTuyenViewModel>()
                .ToList();
        }
        public void AddTuyen(int donvivantaiId, List<DangkyTuyenViewModel> tuyens)
        {

            var newTuyenVm = tuyens.Where(x => x.Id == 0).ToList();
            var updatedTuyenVm = tuyens.Where(x => x.Id != 0).ToList();
            var existedTuyes = _dangkyTuyenRepository.FindAll(x => x.DonviVantaiId == donvivantaiId);

            var newTuyens = Mapper.Map<List<DangkyTuyenViewModel>, List<DangkyTuyen>>(newTuyenVm);
            foreach (var tuyen in newTuyens)
            {
                _dangkyTuyenRepository.Add(tuyen);
            }

            var updatedTuyens = Mapper.Map<List<DangkyTuyenViewModel>, List<DangkyTuyen>>(updatedTuyenVm);
            foreach (var tuyen in updatedTuyens)
            {
                _dangkyTuyenRepository.Update(tuyen);
            }
            _dangkyTuyenRepository.RemoveMultiple(existedTuyes.Except(updatedTuyens).ToList());
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
        public void AddDongia(KekhaiGiaViewModel KKGVm)
        {
            var kkg = Mapper.Map<KekhaiGiaViewModel, KekhaiGia>(KKGVm);
            _kekhaiGiaRepository.Add(kkg);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public KekhaiGiaCalculatorViewModel GetBaseValue(int DKTuyenId)
        {
            var kkg = _kekhaiGiaRepository.
                FindAll(x => x.KekhaiGiaStatus == KekhaiGiaStatus.NewPriceAccepted & x.DangkyTuyenId == DKTuyenId)
                .OrderByDescending(x => x.DateApplied).FirstOrDefault();
            var kkgvm = Mapper.Map<KekhaiGia, KekhaiGiaCalculatorViewModel>(kkg);
            return kkgvm;
        }
    }
}
