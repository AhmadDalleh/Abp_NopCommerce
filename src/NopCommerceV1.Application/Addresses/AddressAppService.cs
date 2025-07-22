using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NopCommerceV1.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NopCommerceV1.Addresses
{
    [RemoteService]
    [Route("api/app/address")]
    public class AddressAppService : ApplicationService, IAddressAppService
    {
        private readonly IRepository<Address,Guid> _addressRepository;
        private readonly AddressManager _addressManager;
        private readonly IMapper _mapper;

        protected AddressAppService()
        {
        }

        public AddressAppService(IRepository<Address, Guid> addressRepository, IMapper mapper, AddressManager addressManager)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _addressManager = addressManager;
        }

        [HttpPost("create-address")]
        public async Task<AddressDto> CreateAsync(CreateAddressDto input)
        {
            var address = await _addressManager.CreateAsync(input.FirstName, input.LastName,
                input.Email, input.ZipPostalCode, input.PhoneNumber, input.Address1, input.City);
            await _addressRepository.InsertAsync(address);
            return _mapper.Map<AddressDto>(address);

        }

        [HttpDelete("delete-address/{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _addressRepository.DeleteAsync(id);
        }

        [HttpGet("get-all-addresses")]
        public async Task<List<AddressDto>> GetAllAsync()
        {
            var address = await _addressRepository.GetListAsync();
            return _mapper.Map<List<Address>, List<AddressDto>>(address);
        }

        [HttpGet("get-address/{id}")]
        public async Task<AddressDto> GetAsync(Guid id)
        {
            var address = await _addressRepository.GetAsync(id);
            return _mapper.Map<Address,AddressDto>(address);
        }

        [HttpPut("update-address/{id}")]
        public async Task<AddressDto> UpdateAsync(Guid id, UpdateAddressDto input)
        {
            var address = await _addressManager.UpdateAsync(id, input.FirstName, input.LastName, input.Email, input.ZipPostalCode,
                input.PhoneNumber, input.Address1, input.City);
            await _addressRepository.UpdateAsync(address);
            return _mapper.Map<AddressDto>(address);
        }
    }
}
