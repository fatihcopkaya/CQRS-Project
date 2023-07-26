using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Abstract.Services
{
    public interface ICustomerService
    {
        Task<IDataResult<Customer>> AddAsync(Customer customer);
        
        Task<IDataResult<List<Customer>>> GetCustomerList();
        Task<IDataResult<Customer>> GetCustomerById(int customerId);

        Task<IResult> UpdateAsync(Customer customer);
        Task<IResult> DeleteAsync(Customer customer);
    }
}
