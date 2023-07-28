using StajProjesiAPI.Application.Abstract.Repositories;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Contacts;
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Persistence.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserRepository _userRepository;

        public AppUserManager(IAppUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IDataResult<AppUser>> AddAsync(AppUser appUser)
        {
            await _userRepository.AddAsync(appUser);
            return new SuccessDataResult<AppUser>(appUser, Messages.AddMessage);
        }

        public Task<IResult> DeleteAsync(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<AppUser>> GetAppUserById(int appUserId)
        {
            var row = await _userRepository.GetFirstOrDefaultAsync(x=>x.Id == appUserId);
            if(row != null)
            {
                return new SuccessDataResult<AppUser>(row);
            }
            return new SuccessDataResult<AppUser>(Messages.NoRecordMessage);
        }

        public async Task<IDataResult<List<AppUser>>> GetAppUserList()
        {
           var list = await _userRepository.GetListAsync(filter:x=>x.IsActive == true);
           
        }

        public Task<IResult> UpdateAsync(AppUser appUser)
        {
            throw new NotImplementedException();
        }
    }
}
