using System;
using AutoMapper;
using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Application.ViewModels.QuanlyGia;
using QLGVT.Application.ViewModels.System;
using QLGVT.Data.Entities;

namespace QLGVT.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AppUserViewModel, AppUser>()
                .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName,
                    c.UserName, c.Email, c.PhoneNumber, c.Avatar, c.Status));

            CreateMap<PermissionViewModel, Permission>()
                .ConstructUsing(c => new Permission(c.RoleId, c.FunctionId, c.CanCreate, c.CanRead, 
                    c.CanUpdate, c.CanDelete));


            CreateMap<DonviVantaiViewModel, DonviVantai>()
                .ConstructUsing(c => new DonviVantai(c.Ten, c.Diachi, c.GPKinhdoanh, c.LHKinhdoanh, 
                    c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<BenxeViewModel, Benxe>()
                .ConstructUsing(c => new Benxe(c.Ten, c.Description, c.SortOrder, c.Status));

            CreateMap<TuyenViewModel, Tuyen>()
                .ConstructUsing(c => new Tuyen(c.XuatphatId, c.DiemdenId, c.Khoangcach, c.Status));

            CreateMap<DangkyTuyenViewModel, DangkyTuyen>()
                .ConstructUsing(c => new DangkyTuyen(c.Id,c.DonviVantaiId, c.TuyenId, c.Note, c.Status));

            CreateMap<KekhaiGiaViewModel, KekhaiGia>()
                .ConstructUsing(c => new KekhaiGia(c.SLTG, c.SLTGRate,
                            c.CPNL, c.CPNLRate, 
                            c.CPNCTT, c.CPNCTTRate, 
                            c.CPKHTB, c.CPKHTBRate, 
                            c.CPSXKDDT, c.CPSXKDDTRate, 
                            c.CPSXC, c.CPSXCRate,
                            c.CPTC, c.CPTCRate, 
                            c.CPBH, c.CPBHRate, 
                            c.CPQL, c.CPQLRate,
                            c.LoinhuanDukien,c.GiathanhVe,c.Note,
                            c.DangkyTuyenId,c.KekhaiGiaBaseId, c.KekhaiGiaStatus));
        }
    }
}
