using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceV1.Customers
{
    public class CustomerDto
    {
        #region Propertis for gets customer info
        public Guid Id { get; set; }

        public string Email { get; set; } 

        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? Active { get; set; }

        //public Guid? BillingAddressId { get; set; }

        //public Guid? ShippingAddressId { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        #endregion
    }
}
