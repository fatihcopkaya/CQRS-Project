using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using StajProjesiAPI.Application.Abstract.Repositories;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Contacts;
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;
using StajProjesiAPI.Infrastructure.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Persistence.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHashingHelperService _hashingHelperService;

        public AppUserManager(IAppUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IHashingHelperService hashingHelperService)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _hashingHelperService = hashingHelperService;
        }

        public async Task<IDataResult<AppUser>> AddAsync(AppUser appUser)
        {
            await _userRepository.AddAsync(appUser);
            return new SuccessDataResult<AppUser>(appUser, Messages.AddMessage);
        }

        public async Task<IResult> DeleteAsync(AppUser appUser)
        {
            await _userRepository.UpdateAsync(appUser);
            return new SuccessDataResult<AppUser>(Messages.DeleteMessage);
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
            return new SuccessDataResult<List<AppUser>>(list.ToList());
           
        }

        public async Task<IDataResult<AppUser>> GetAuthenticatedUser()
        {
            string usermail = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.Email)?.Value;
            var userId = (await _userRepository.GetListAsync()).Where(x=>x.Email == usermail).Select(x=>x.Id).FirstOrDefault();
            var row = await _userRepository.GetFirstOrDefaultAsync(x=>x.Id==userId);
            if(row != null)
            {
                return new SuccessDataResult<AppUser>(row);
            }
            return new SuccessDataResult<AppUser>(Messages.NoRecordMessage);
        }

        public async Task<IDataResult<AppUser>> GetByEmailAsync(string appUserEmail)
        {
            var row = await _userRepository.GetFirstOrDefaultAsync(x=>x.Email == appUserEmail);
            if(row != null) 
            {
                return new SuccessDataResult<AppUser>(row);
            }
            return new SuccessDataResult<AppUser>(Messages.NoRecordMessage);
        }

        public async Task<IDataResult<AppUser>> GetByRefreshTokenAsync(string userRefreshToken)
        {
            var row = await _userRepository.GetFirstOrDefaultAsync(x=>x.RefreshToken == userRefreshToken);
            if(row != null)
            {
                return new SuccessDataResult<AppUser>(row);
            }
            return new ErrorDataResult<AppUser>(new AppUser(), Messages.NoRecordMessage);
        }

        public async Task<IDataResult<AppUser>> SignInAsync(string email, string password)
        {
            var row = await _userRepository.GetFirstOrDefaultAsync(x => x.Email == email.Trim());
            if(row != null) 
            { 
                var IsPasswordValid = _hashingHelperService.VerifyPasswordHash(password, row.PasswordHash,row.PasswordSalt);
                if(IsPasswordValid) 
                {
                    var identity = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, row.FirstName),
                        new Claim(ClaimTypes.Email, row.Email),
                        new Claim(ClaimTypes.Role, row.Role)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                    bool isAuthentication = true;
                    var pricipal = new ClaimsPrincipal(identity);
                    if(isAuthentication == true) 
                    { 
                        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, pricipal, new AuthenticationProperties 
                        { 
                            ExpiresUtc = DateTime.UtcNow,
                            IsPersistent = true,
                            AllowRefresh = false

                        });
                        return new SuccessDataResult<AppUser>(row, Messages.SuccesfulLogin);
                    
                    
                    }
                }


            }
            return new ErrorDataResult<AppUser>(new AppUser(), Messages.UserNotFound);
        }

        public async Task<IDataResult<AppUser>> SignInAsyncWithToken(string email, string password)
        {
            var row = await _userRepository.GetFirstOrDefaultAsync(x=> x.Email == email.Trim());
            if(row != null)
            {
                var isPasswordValid = _hashingHelperService.VerifyPasswordHash(password, row.PasswordHash, row.PasswordSalt);
                if(isPasswordValid) 
                {
                    return new SuccessDataResult<AppUser>(row,Messages.SuccesfulLogin);
                
                }
                return new SuccessDataResult<AppUser>(Messages.PasswordError);
            }
            return new SuccessDataResult<AppUser>(Messages.UserNotFound);
        }

        public async Task<IResult> UpdateAsync(AppUser appUser)
        {
           await _userRepository.UpdateAsync(appUser);
            return new SuccessDataResult<AppUser>(new AppUser(), Messages.UpdateMessage);
        }
    }
}
