using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class DeleteAppUserCommandRequest : IRequest<DeleteAppUserCommandResponse>
    {
    }
}
