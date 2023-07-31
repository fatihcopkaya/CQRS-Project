using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Queries
{
    public class AppUserLoginControlQueryHandler : IRequestHandler<AppUserLoginControlQueryRequest, AppUserLoginControlQueryResponse>
    {
        private readonly IAppUserService _appUserService;

        public AppUserLoginControlQueryHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<AppUserLoginControlQueryResponse> Handle(AppUserLoginControlQueryRequest request, CancellationToken cancellationToken)
        {
            var appUserControl = request.AppUserLoginDto;
            var appUser = await _appUserService.SignInAsyncWithToken(appUserControl.Email, appUserControl.Password);
            
                return new AppUserLoginControlQueryResponse
                {
                    AppUser = appUser.Data
                };
            
            
           
          
        }
    }
}
