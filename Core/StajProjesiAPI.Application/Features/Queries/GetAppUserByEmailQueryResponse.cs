using MediatR;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetAppUserByEmailQueryResponse : IRequest<GetAppUserByEmailQueryResponse>
    {
        public AppUser AppUser { get; set; }
    }
}
