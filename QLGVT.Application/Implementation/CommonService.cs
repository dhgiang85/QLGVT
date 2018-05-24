using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using QLGVT.Application.Interfaces;
using QLGVT.Application.ViewModels.Common;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;
using QLGVT.Infrastructure.Interfaces;
using QLGVT.Utilities.Constants;

namespace QLGVT.Application.Implementation
{
    public class CommonService : ICommonService
    {
        IFooterRepository _footerRepository;
        ISystemConfigRepository _systemConfigRepository;
        ISlideRepository _slideRepository;

        public CommonService(IFooterRepository footerRepository,
            ISystemConfigRepository systemConfigRepository,
            ISlideRepository slideRepository)
        {
            _footerRepository = footerRepository;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
        }

        public FooterViewModel GetFooter()
        {
            return Mapper.Map<Footer, FooterViewModel>(
                _footerRepository.FindSingle(x => x.Id == CommonConstants.DefaultFooterId));
        }
        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _slideRepository.FindAll(x => x.Status && x.GroupAlias == groupAlias)
                .ProjectTo<SlideViewModel>().ToList();
        }
        public SystemConfigViewModel GetSystemConfig(string code)
        {
            return Mapper.Map<SystemConfig, SystemConfigViewModel>(
                _systemConfigRepository.FindSingle(x => x.Id == code));
        }
    }
}
