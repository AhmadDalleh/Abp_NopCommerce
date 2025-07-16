using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace NopCommerceV1.Addresses
{
    [RemoteService]
    public interface IAddressAppService : IApplicationService 
    {
        Task<AddressDto> GetAsync(Guid id);
        Task<List<AddressDto>> GetAllAsync();
        Task<AddressDto> CreateAsync(CreateAddressDto addressDto);
        Task<AddressDto> UpdateAsync(Guid id, UpdateAddressDto addressDto);
        Task DeleteAsync(Guid id);
    }
}
