using MediatR;
using StajProjesiAPI.Domain.Entities;

namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetCustomerByIdQueryResponse : IRequest<GetCustomerByIdQueryRequest>
    {
        public Customer Customer { get; set; }
    }
}
