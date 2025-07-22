using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;


namespace NopCommerceV1.Customers
{
    
    [RemoteService]
    [Route("api/app/customer")]
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        #region Properties
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly CustomerManager _customerManager;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public CustomerAppService(IRepository<Customer, Guid> customerRepository, CustomerManager customerManager, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _customerManager = customerManager;
            _mapper = mapper;
        }


        #endregion

        #region Methods
        // get all
        [HttpGet("get-all-customers")]
        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            var customer = await _customerRepository.GetListAsync();
            return _mapper.Map<List<Customer>, List<CustomerDto>>(customer);
        }
        
        // get by id
        [HttpGet("get-customer/{id}")]
        public async Task<CustomerDto> GetCustomerAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        //delete by id
        [HttpDelete("delete-customer/{id}")]
        public async Task DeleteAsync(Guid id) 
        {
            await _customerRepository.DeleteAsync(id);
        }

        // create
        [HttpPost("create-customer")]
        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto input)
        {
            var customer = await _customerManager.CreateAsync(
                input.Username, input.Email, input.FirstName, input.LastName, input.PhoneNumber
                );
            await _customerRepository.InsertAsync(customer);

            return _mapper.Map<CustomerDto>(customer);

        }

        //update 
        [HttpPut("update-customer/{id}")]
        public async Task<CustomerDto> UpdateCustomerAsync(UpdateCustomerDto input,Guid id)
        {
            var customer = await _customerManager.UpdateAsync(
                id,input.Username, input.Email, input.FirstName, input.LastName, input.PhoneNumber
                );
            await _customerRepository.UpdateAsync(customer);

            return _mapper.Map<CustomerDto>(customer);

        }

        #endregion


    }
}
