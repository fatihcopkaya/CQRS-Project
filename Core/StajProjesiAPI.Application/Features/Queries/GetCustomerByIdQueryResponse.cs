using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetCustomerByIdQueryResponse : IRequest<GetCustomerByIdQueryRequest>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
