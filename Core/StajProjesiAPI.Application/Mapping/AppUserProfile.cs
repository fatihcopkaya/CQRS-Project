using AutoMapper;
using StajProjesiAPI.Application.Dtos.AppUser;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Mapping
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<CreateAppUserDto, AppUser>().ReverseMap();
        }

        
    }
}
