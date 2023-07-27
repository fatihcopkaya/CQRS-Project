using AutoMapper;
using MediatR;
using StajProjesiAPI.Application.Abstract.Services;


namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, GetAllCustomerQueryResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<GetAllCustomerQueryResponse> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await _customerService.GetCustomerList();

            var response = new GetAllCustomerQueryResponse() 
            { 
                 Customers = list.Data.ToList()
              
            
            };
            return response;
        }
    }
}
