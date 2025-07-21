using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace NopCommerceV1.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<CustomerDto> GetAsync(Guid id);
        Task<List<CustomerDto>> GetListAsync();
        Task<CustomerDto> CreateAsync(CreateCustomerDto createCustomerDto);
        Task<CustomerDto> UpdateAsync(UpdateCustomerDto updateCustomerDto, Guid id);
        Task DeleteAsync(Guid id);
    }
}
