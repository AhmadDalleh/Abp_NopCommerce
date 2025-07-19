using NopCommerceV1.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace NopCommerceV1.Customers
{
    public class Customer : FullAuditedAggregateRoot<Guid>
    {
        #region Ctor
        // Constructor for EF Core
        protected Customer() { }

        // Optional constructor for easier creation
        public Customer(Guid id, string username, string email, string? phoneNumber, bool active, bool deleted)
            : base(id)
        {
            Username = username;
            Email = email;
            PhoneNumber = phoneNumber;
            Active = active;
            Deleted = deleted;

        }
        #endregion

        #region Table Coulmns 
        public string Username { get; set; }
        public string FirstName {  get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }             // maps to Deleted
        public Guid? BillingAddressId { get; set; }
        public Guid? ShippingAddressId { get; set; }


        #endregion

        #region Navigation Properties
        public virtual Address? BillingAddress { get; set; }
        public virtual Address? ShippingAddress { get; set; }
        public virtual ICollection<CustomerRole> CustomerRoles { get; set; } = new List<CustomerRole>();
        public virtual ICollection<CustomerPassword> CustomerPasswords { get; set; } = new List<CustomerPassword>();
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();


        #endregion

    }
}
