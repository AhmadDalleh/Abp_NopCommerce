using Scriban.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace NopCommerceV1.Customers
{
    public class AddressManager : DomainService
    {
        #region property
        private readonly IRepository<Address, Guid> _addressRepository;

        #endregion

        #region Ctor
        public AddressManager(IRepository<Address, Guid> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        #endregion

        #region Methods
       


        public async Task ValidateAddressAsync(Guid? addressId, string email, string phoneNumber)
        {
            var existingByEmail = await _addressRepository.FirstOrDefaultAsync(c => c.Email == email && c.Id != addressId);
            if (existingByEmail != null)
                throw new BusinessException("Address.EmailAlreadyExists").WithData("Email", email);

            var existingByUsername = await _addressRepository.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber && c.Id != addressId);
            if (existingByUsername != null)
                throw new BusinessException("Address.PhoneAlreadyExists").WithData("Username", phoneNumber);


        }


        public async Task<Address> CreateAsync(string firstName, string lastName, string email, string zipPostalCode, string phoneNumber,string address1,string city)
        {
            await ValidateAddressAsync(null, email, phoneNumber);
            var address = new Address(Guid.NewGuid(), firstName, lastName, email)
            {
                ZipPostalCode = zipPostalCode,
                PhoneNumber = phoneNumber,
                Address1 = address1,
                City = city
            };
            return address;
        }

        public async Task<Address> UpdateAsync(Guid id, string firstName, string lastName, string email, string zipPostalCode, string phoneNumber, string address1, string city)
        {
            var address = await _addressRepository.FindAsync(c => c.Id == id);
            if (address is null)
            {
                throw new BusinessException(
                    NopCommerceV1DomainErrorCodes.CustomerIsNotExist, "there is no account with this id."
                    );
            }
            await ValidateAddressAsync(id, email,phoneNumber);
            address.Email = email;
            address.FirstName = firstName;
            address.LastName = lastName;
            address.PhoneNumber = phoneNumber;
            address.ZipPostalCode = zipPostalCode;
            address.Address1 = address1;
            address.City = city;


            return address;
        }

        #endregion
        
    }
}
