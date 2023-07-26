using AutoMapper;
using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Domain.Dtos.Customer;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customerDTO = request.CustomerDto;
            var mappedCustomer = _mapper.Map<CustomerDTO, Customer>(customerDTO, new Customer());
            mappedCustomer.CreatedDate = DateTime.Now;
            var CreatedCustomer = await _customerService.AddAsync(mappedCustomer);
            if(CreatedCustomer.Success) 
            {
                return new CreateCustomerCommandResponse()
                {
                    IsSuccess = true,

                };
            }
            return new CreateCustomerCommandResponse()
            {

                    IsSuccess = false,
            };
           

        }
    }
}
