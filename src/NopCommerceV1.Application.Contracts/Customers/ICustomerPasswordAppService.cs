using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace NopCommerceV1.Customers
{
    public interface ICustomerPasswordAppService : ICrudAppService<
        CustomerPasswordDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCustomerPasswordDto>
    {

    }
}
