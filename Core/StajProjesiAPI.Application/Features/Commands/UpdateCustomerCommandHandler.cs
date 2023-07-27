using AutoMapper;
using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Features.Queries;


namespace StajProjesiAPI.Application.Features.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateCustomerCommandHandler(ICustomerService customerService, IMapper mapper, IMediator mediator)
        {
            _customerService = customerService;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            
            try 
            {
                var getCustomerQuery = new GetCustomerByIdQueryRequest() { Id = request.Id };
                var customerQueryResponse = await _mediator.Send(getCustomerQuery);


                if (customerQueryResponse.Customer != null)
                {
                    customerQueryResponse.Customer.Name = request.Name;
                    customerQueryResponse.Customer.Id = request.Id;
                    var updatedCustomer = await _customerService.UpdateAsync(customerQueryResponse.Customer);
                    if (updatedCustomer.Success)
                    {
                        return new UpdateCustomerCommandResponse()
                        {
                            IsSuccess = updatedCustomer.Success



                        };
                    }
                }


            }
            catch (Exception ex) 
            {
                return new UpdateCustomerCommandResponse()
                {
                    IsSuccess = false
                };
            
            
            
            }
            return new UpdateCustomerCommandResponse()
            {
                IsSuccess = false
            };




        }
    }
}
