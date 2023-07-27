using MediatR;


namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetCustomerByIdQueryRequest : IRequest<GetCustomerByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
