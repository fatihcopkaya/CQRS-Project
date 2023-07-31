using AutoMapper;
using MediatR;
using StajProjesiAPI.Application.Abstract.Services;


namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAppUserByEmailRequest, GetAllCustomerQueryResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<GetAllCustomerQueryResponse> Handle(GetAppUserByEmailRequest request, CancellationToken cancellationToken)
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
