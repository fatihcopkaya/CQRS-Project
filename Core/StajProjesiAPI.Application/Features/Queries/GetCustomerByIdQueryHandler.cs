using AutoMapper;
using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryRequest, GetCustomerByIdQueryResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var row = await _customerService.GetCustomerById(request.Id);
            var response = new GetCustomerByIdQueryResponse()
            {
                Id = row.Data.Id,
                Name = row.Data.Name

            };
            return response;
        }
    }
}
