using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using NopCommerceV1.Customers;


namespace NopCommerceV1.Customers
{
    public class CustomerPassword : FullAuditedEntity<Guid>
    {
        #region Ctor
        protected CustomerPassword() { }

        public CustomerPassword(Guid id, Guid customerId, string password, PasswordFormat format, DateTime createdOnUtc)
            : base(id)
        {
            CustomerId = customerId;
            Password = password;
            PasswordFormatId = format;
            CreatedOnUtc = createdOnUtc;
        }
        #endregion

        #region Table Columns 
        public Guid CustomerId { get; set; }

        public string Password { get; set; } // Renamed from PasswordHash

        public PasswordFormat PasswordFormatId { get; set; } // Matches nopCommerce

        public DateTime CreatedOnUtc { get; set; }

        public virtual Customer Customer { get; set; }

        #endregion


    }
}
