using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Features.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Login
{
    public class AppUserLoginCommandHandler : IRequestHandler<AppUserLoginCommandRequest, AppUserLoginCommandResponse>
    {
        private readonly IAppUserService _appUserService;

        private readonly JWTTokenService _jwtTokenService;
        private readonly IMediator _mediator;

        public AppUserLoginCommandHandler(IAppUserService appUserService, JWTTokenService jwtTokenService, IMediator mediator)
        {
            _appUserService = appUserService;
            _jwtTokenService = jwtTokenService;
            _mediator = mediator;
        }

        public async Task<AppUserLoginCommandResponse> Handle(AppUserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            try 
            {
                var appUserDto = request.AppUserLoginDto;
                var AppUserControlQuery = new AppUserLoginControlQueryRequest() { AppUserLoginDto = appUserDto };
                var AppUserControlResponse = await _mediator.Send(AppUserControlQuery);
                var appUserControl = AppUserControlResponse.AppUser;
                if(appUserControl != null) 
                {

                    var TokenVM = _jwtTokenService.GetToken(appUserControl.Email, appUserControl.Role);
                    appUserControl.RefreshToken = TokenVM.RefreshToken;
                    appUserControl.RefreshTokenEndDate = TokenVM.RefreshTokenEndDate;
                    
                    await _appUserService.UpdateAsync(appUserControl);
                    return new AppUserLoginCommandResponse
                    {
                        TokenVM = TokenVM
                    };

                }
            
            }
            catch(Exception ex) 
            {
                return new AppUserLoginCommandResponse { TokenVM = null };
            }
            return new AppUserLoginCommandResponse { TokenVM = null };

        }
    }
}
