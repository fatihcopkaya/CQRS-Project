using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetAuthenticatedUserQueryHandler : IRequestHandler<GetAuthenticatedUserQueryRequest, GetAuthenticatedUserQueryResponse>
    {
        private readonly IAppUserService _appUserService;

        public GetAuthenticatedUserQueryHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<GetAuthenticatedUserQueryResponse> Handle(GetAuthenticatedUserQueryRequest request, CancellationToken cancellationToken)
        {
            var authenticatedAppUser = await _appUserService.GetAuthenticatedUser();
            return new GetAuthenticatedUserQueryResponse
            {
                AppUser = authenticatedAppUser.Data
            };


        }
    }
}
