using MediatR;
using StajProjesiAPI.Application.Dtos.AppUser;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class UpdateAppUserCommandRequest : IRequest<UpdateAppUserCommandResponse>
    {
        public UpdateAppUserDto UpdateAppUserDto { get; set; }
    }
}
