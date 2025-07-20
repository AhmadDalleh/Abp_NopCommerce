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

        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly IRepository<CustomerPassword, Guid> _passwordRepository;
        private readonly IRepository<CustomerRole,Guid> _roleRepository;

        #endregion

        #region Ctor
        public CustomerManager(IRepository<Customer, Guid> customerRepository, IRepository<CustomerPassword, Guid> passwordRepository, IRepository<CustomerRole, Guid> roleRepository)
        {
            _customerRepository = customerRepository;
            _passwordRepository = passwordRepository;
            _roleRepository = roleRepository;
        }
        #endregion

        #region Methods 
        public async Task<Customer> CreateAsync(string username, string email, string firstName, string lastName)
        {
            if(await _customerRepository.AnyAsync(x=>x.Email == email || x.Username == username))
            {
                throw new BusinessException("Customer with this email or user name is already exists");
            }
            var customer = new Customer(GuidGenerator.Create(), username, email, null, active: true, deleted: false)
            {
                FirstName = firstName,
                LastName = lastName,
                CreatedOnUtc = DateTime.UtcNow
            };
            return await _customerRepository.InsertAsync(customer, autoSave: true);
        }



    #endregion
}
}
