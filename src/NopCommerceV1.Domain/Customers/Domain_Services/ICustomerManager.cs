using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceV1.Customers.Domain_Services
{
    public interface ICustomerManager
    {
        Task RegisterAsync(Customer customer, string password, string roleSystemName);
        Task<bool> IsActiveAsync(Guid customerId);
    }
}
