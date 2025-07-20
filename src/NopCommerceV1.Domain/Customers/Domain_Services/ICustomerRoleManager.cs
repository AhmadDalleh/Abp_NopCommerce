using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceV1.Customers.Domain_Services
{
    public interface ICustomerRoleManager
    {
        Task<bool> IsInRoleAsync(Guid customerId, string systemName);
        Task AddToRoleAsync(Guid customerId, string roleSystemName);
    }
}
