using MediatR;
using StajProjesiAPI.Application.Dtos.ProductPhoto;
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands.ProductsPhoto
{
    public class CreateProductPhotoCommandRequest : IRequest<CreateProductPhotoCommandResponse>
    {
        public string FileCode { get; set; }
        public int ProductId { get; set; }
    }
}
