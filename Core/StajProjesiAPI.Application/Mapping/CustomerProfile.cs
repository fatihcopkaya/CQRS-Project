using AutoMapper;
using StajProjesiAPI.Domain.Dtos.Customer;
using StajProjesiAPI.Domain.Entities;

namespace StajProjesiAPI.Application.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            

        }
    }
}
