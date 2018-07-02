using AutoMapper;
using QLGVT.Application.ViewModels.Common;
using QLGVT.Application.ViewModels.QuanlyGia;
using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Application.ViewModels.System;
using QLGVT.Data.Entities;

namespace QLGVT.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //----------------------------------------------

            CreateMap<AppUser, AppUserViewModel>();

            CreateMap<AppRole, AppRoleViewModel>();

            CreateMap<Function, FunctionViewModel>();

            //----------------------------------------------

            CreateMap<SystemConfig, SystemConfigViewModel>().MaxDepth(2);

            CreateMap<Footer, FooterViewModel>().MaxDepth(2);

            CreateMap<Slide, SlideViewModel>().MaxDepth(2);

            //----------------------------------------------

            CreateMap<DonviVantai, DonviVantaiViewModel>();

            CreateMap<Benxe, BenxeViewModel>();

            CreateMap<Tuyen, TuyenViewModel>().MaxDepth(2);

            CreateMap<DangkyTuyen, DangkyTuyenViewModel>().MaxDepth(2);

            //---------------------------------------------

            CreateMap<KekhaiGia, KekhaiGiaViewModel>().MaxDepth(2);

            CreateMap<KekhaiGia, KekhaiGiaCalculatorViewModel>().MaxDepth(2);

            CreateMap<KekhaiGiaRate, KekhaiGiaRateViewModel>().MaxDepth(2);


        }
    }
}
