using AutoMapper;
using StajProjesiAPI.Application.Dtos.ProductPhoto;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Mapping
{
    public class ProductPhotoProfile : Profile
    {
        public ProductPhotoProfile()
        {
            CreateMap<CreateProductPhotoDto,ProductPhoto>().ReverseMap();
        }
    }
}
