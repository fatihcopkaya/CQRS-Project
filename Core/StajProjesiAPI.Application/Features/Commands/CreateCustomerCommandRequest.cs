using MediatR;
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
    {
        public CustomerDTO CustomerDto { get; set; }
    }
}
