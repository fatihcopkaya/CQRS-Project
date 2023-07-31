using MediatR;
using StajProjesiAPI.Application.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class CreateAppUserCommandResponse : IRequest<CreateAppUserCommandResponse>
    {
        public bool IsSuccess { get; set; }
    }
}
