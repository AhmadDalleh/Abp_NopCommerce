using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NopCommerceV1.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NopCommerceV1.Customers
{
    [RemoteService]
    [Route("api/app/address")]
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly IRepository<Customer,Guid> _customerRepository;
        private readonly IMapper _mapper;
        public CustomerAppService(IRepository<Customer, Guid> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpPost("create-customer")]
        public async Task<CustomerDto> CreateAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<CreateCustomerDto, Customer>(createCustomerDto);
            await _customerRepository.InsertAsync(customer);
            return _mapper.Map<CustomerDto>(customer);
        }

        [HttpDelete("delete-customer/{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        [HttpGet("get-customer-by-id/{id}")]
        public async Task<CustomerDto> GetAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);
            return _mapper.Map<Customer,CustomerDto>(customer);
        }

        [HttpGet("get-all-customers")]
        public async Task<List<CustomerDto>> GetListAsync()
        {
            var customers = await _customerRepository.GetListAsync();
            return _mapper.Map<List<Customer>,List<CustomerDto>>(customers);
        }

        [HttpPut("update-customer/{id}")]
        public async Task<CustomerDto> UpdateAsync(UpdateCustomerDto updateCustomerDto,Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);
            _mapper.Map(updateCustomerDto, customer);
            await _customerRepository.UpdateAsync(customer);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
