using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Abstract.Services
{
    public interface IAppUserService
    {
        Task<IDataResult<AppUser>> AddAsync(AppUser appUser);

        Task<IDataResult<List<AppUser>>> GetAppUserList();
        Task<IDataResult<AppUser>> GetAppUserById(int appUserId);

        Task<IResult> UpdateAsync(AppUser appUser);
        Task<IResult> DeleteAsync(AppUser appUser);
    }
}
