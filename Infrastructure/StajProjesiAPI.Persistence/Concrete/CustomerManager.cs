using StajProjesiAPI.Application.Abstract.Repositories;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Contacts;
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Persistence.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IDataResult<Customer>> AddAsync(Customer customer)
        {
            await _customerRepository.AddAsync(customer);
            return new SuccessDataResult<Customer>(customer,Messages.AddMessage);
        }

        public async Task<IResult> DeleteAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
            return new SuccessDataResult<Customer>(Messages.DeleteMessage);
        }

        public async Task<IDataResult<Customer>> GetCustomerById(int customerId)
        {
            var row = await _customerRepository.GetFirstOrDefaultAsync(x=>x.Id == customerId);
            return row != null ?  new SuccessDataResult<Customer>(row) : new ErrorDataResult<Customer>(Messages.NoRecordMessage);
        }

        public async Task<IDataResult<List<Customer>>> GetCustomerList()
        {
            var list = await _customerRepository.GetListAsync();
            return new SuccessDataResult<List<Customer>>(list.ToList());
        }

        public async Task<IResult> UpdateAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
            return new SuccessDataResult<Customer>(customer,Messages.UpdateMessage);
        }
    }
}
