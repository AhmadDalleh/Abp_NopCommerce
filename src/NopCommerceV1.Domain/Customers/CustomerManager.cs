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

        public async Task<Customer> UpdateAsync(Guid id,string username,string email, string firstName, string lastName, string phoneNumber)
        {
            var customer = await _customerRepository.FindAsync(c=>c.Id==id);
            if (customer is null)
            {
                throw new BusinessException(
                    NopCommerceV1DomainErrorCodes.CustomerIsNotExist, "there is no account with this id."
                    );
            }
            var existEmail = await _customerRepository.FirstOrDefaultAsync(c =>
                (c.Email == email && email != customer.Email) ||
                (c.Username == username && username != customer.Username) ||
                (c.PhoneNumber == phoneNumber && phoneNumber == customer.PhoneNumber)
                );

            if (existEmail is not null) 
            {
               
               throw new BusinessException(
               NopCommerceV1DomainErrorCodes.CustomerEmailAlreadyExists,
               "the customer is already exists.");
                
            }
            customer.Username = username;
            customer.Email = email;
            customer.FirstName = firstName; 
            customer.LastName = lastName;
            customer.PhoneNumber = phoneNumber;

            return customer;
        }
       
    #endregion
    }
}
