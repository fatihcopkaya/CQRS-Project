using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommandRequest, DeleteAppUserCommandResponse>
    {
        private readonly IAppUserService _appUserService;

        public DeleteAppUserCommandHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public Task<DeleteAppUserCommandResponse> Handle(DeleteAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
