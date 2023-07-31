using MediatR;
using StajProjesiAPI.Application.Dtos.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class CreateAppUserCommandRequest : IRequest<CreateAppUserCommandResponse>
    {
        public CreateAppUserDto CreateAppUserDTO { get; set; }
    }
}
