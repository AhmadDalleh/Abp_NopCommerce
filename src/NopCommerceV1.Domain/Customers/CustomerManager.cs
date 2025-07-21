using NopCommerceV1.Customers.Constants;
using NopCommerceV1.Customers.Enums;
using NopCommerceV1.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace NopCommerceV1.Customers
{
    public class CustomerManager : DomainService
    {
        #region Properties 

        private readonly IRepository<Customer,Guid> _customerRepository;

        #endregion

        #region Ctor
        public CustomerManager(IRepository<Customer, Guid> customerRepository)
        {
            _customerRepository = customerRepository;

        }
        #endregion

        #region Methods 
        public async Task<Customer> CreateAsync(string username, string email, string firstName, string lastName , string phoneNumber)
        {
            var existingCustomer = await _customerRepository.FirstOrDefaultAsync(c => c.Email == email || c.Username == username || c.PhoneNumber == phoneNumber);
            if (existingCustomer is not null)
            {
                throw new BusinessException(
        NopCommerceV1DomainErrorCodes.CustomerEmailAlreadyExists,
       "A customer with this email already exists.");
            }


            var customer = new Customer(Guid.NewGuid(), username, email, phoneNumber, true, false)
            {
                FirstName = firstName,
                LastName = lastName,
                CreatedOnUtc = DateTime.UtcNow
            };
            return customer;
        }
       
    #endregion
    }
}
