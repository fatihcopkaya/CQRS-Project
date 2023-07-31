using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetAppUserByEmailQueryHandler : IRequestHandler<GetAppUserByEmailQueryRequest, GetAppUserByEmailQueryResponse>
    {
        private readonly IAppUserService _appUserService;

        public GetAppUserByEmailQueryHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<GetAppUserByEmailQueryResponse> Handle(GetAppUserByEmailQueryRequest request, CancellationToken cancellationToken)
        {
            var row = await _appUserService.GetByEmailAsync(request.Email);
            return new GetAppUserByEmailQueryResponse
            {
                AppUser = row.Data

            };
        }
    }
}
