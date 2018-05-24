﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QLGVT.Application.ViewModels.System;
using QLGVT.Utilities.Dtos;

namespace QLGVT.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(AppUserViewModel userVm);

        Task DeleteAsync(string id);

        Task<List<AppUserViewModel>> GetAllAsync();

        PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppUserViewModel> GetById(string id);


        Task UpdateAsync(AppUserViewModel userVm);
    }
}
