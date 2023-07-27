using MediatR;
using StajProjesiAPI.Domain.Entities;


namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetAllCustomerQueryResponse : IRequest<GetAllCustomerQueryRequest>
    {
         public List<Customer> Customers { get; set; }
        

    }
}
