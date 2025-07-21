using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("create-customer")]
        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto input)
        {
            var customer = await _customerManager.CreateAsync(
                input.Username, input.Email, input.FirstName, input.LastName, input.PhoneNumber
                );
            await _customerRepository.InsertAsync(customer);

            return _mapper.Map<CustomerDto>(customer);

        }
     
        #endregion

        #region Methods
        #endregion


    }
}
