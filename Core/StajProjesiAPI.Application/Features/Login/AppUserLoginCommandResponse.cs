using MediatR;
using StajProjesiAPI.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Login
{
    public class AppUserLoginCommandResponse : IRequest<AppUserLoginCommandRequest>
    {
        public TokenVM TokenVM { get; set; }
    }
}
