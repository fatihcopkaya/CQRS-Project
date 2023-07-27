using AutoMapper;
using StajProjesiAPI.Application.Features.Queries;
using StajProjesiAPI.Domain.Dtos.Customer;
using StajProjesiAPI.Domain.Entities;

namespace StajProjesiAPI.Application.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, GetCustomerByIdQueryResponse>().ReverseMap();
            

        }
    }
}
