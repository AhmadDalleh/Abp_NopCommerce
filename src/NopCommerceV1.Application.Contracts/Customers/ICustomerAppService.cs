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
        Task<CustomerDto> GetCustomerAsync(Guid id);
        Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto input);
        Task<List<CustomerDto>> GetCustomersAsync();

        Task<CustomerDto> UpdateCustomerAsync(UpdateCustomerDto input, Guid id);

        Task DeleteAsync(Guid id);
    }
}
