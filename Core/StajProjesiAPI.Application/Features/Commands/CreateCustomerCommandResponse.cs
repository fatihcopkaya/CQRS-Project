using MediatR;
using StajProjesiAPI.Application.Contacts;
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class CreateCustomerCommandResponse : IRequest<CreateCustomerCommandRequest>
    {
        public bool IsSuccess { get; set; }
        
    }
}
