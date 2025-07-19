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
        private readonly IRepository<Address,Guid> _repository;

        private readonly IMapper _mapper;

        protected AddressAppService()
        {
        }

        public AddressAppService(IRepository<Address, Guid> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("create-address")]
        public async Task<AddressDto> CreateAsync(CreateAddressDto addressDto)
        {
            var address = _mapper.Map<CreateAddressDto, Address>(addressDto);
            await _repository.InsertAsync(address);
            return _mapper.Map<AddressDto>(address);

        }
        [HttpDelete("delete-address/{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
        [HttpGet("get-all-addresses")]
        public async Task<List<AddressDto>> GetAllAsync()
        {
            var address = await _repository.GetListAsync();
            return _mapper.Map<List<Address>, List<AddressDto>>(address);
        }
        [HttpGet("get-address/{id}")]
        public async Task<AddressDto> GetAsync(Guid id)
        {
            var address = await _repository.GetAsync(id);
            return _mapper.Map<Address,AddressDto>(address);
        }
        [HttpPut("update-address/{id}")]
        public async Task<AddressDto> UpdateAsync(Guid id, UpdateAddressDto addressDto)
        {
            var address = await _repository.GetAsync(id); 
            _mapper.Map(addressDto,address );
            await _repository.UpdateAsync(address);
            return _mapper.Map<AddressDto>(address);
        }
    }
}
