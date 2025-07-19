using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceV1.Customers
{
    public class UpdateCustomerDto
    {
        #region Propeties 

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Username { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        public bool Active { get; set; } = true;

        public Guid? BillingAddressId { get; set; }

        public Guid? ShippingAddressId { get; set; }

        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;

        #endregion

    }
}
