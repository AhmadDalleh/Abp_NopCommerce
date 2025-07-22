using NopCommerceV1.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace NopCommerceV1
{
    public class NopCommerceV1DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly IRepository<Address, Guid> _addressRepository;

        public NopCommerceV1DataSeedContributor(IRepository<Customer, Guid> customerRepository, IRepository<Address, Guid> addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // Create addresses
            //var address1 = await _addressRepository.InsertAsync(
            //    new Address(Guid.NewGuid(), "John", "Doe", "john@example.com")
            //    {
            //        City = "New York",
            //        Address1 = "123 Main St",
            //        ZipPostalCode = "10001",
            //        PhoneNumber = "111-111-1111"
            //    }, autoSave: true);

            //var address2 = await _addressRepository.InsertAsync(
            //    new Address(Guid.NewGuid(), "Sara", "Smith", "sara@example.com")
            //    {
            //        City = "Los Angeles",
            //        Address1 = "456 Sunset Blvd",
            //        ZipPostalCode = "90001",
            //        PhoneNumber = "222-222-2222"
            //    }, autoSave: true);

            //// Create customers linked to addresses
            //var customer1 = new Customer(Guid.NewGuid(), "johnny", "john@example.com", "111-111-1111", true, false)
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    BillingAddressId = address1.Id,
            //    ShippingAddressId = address1.Id
            //};

            //var customer2 = new Customer(Guid.NewGuid(), "saraa", "sara@example.com", "222-222-2222", true, false)
            //{
            //    FirstName = "Sara",
            //    LastName = "Smith",
            //    BillingAddressId = address2.Id,
            //    ShippingAddressId = address2.Id
            //};

            //await _customerRepository.InsertAsync(customer1, autoSave: true);
            //await _customerRepository.InsertAsync(customer2, autoSave: true);
        }
    }
}
