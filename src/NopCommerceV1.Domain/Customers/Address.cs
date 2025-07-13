using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace NopCommerceV1.Customers
{
    public class Address :FullAuditedEntity<Guid>
    {

        #region Ctor
        protected Address()
        {
        }

        public Address(Guid id, string firstName, string lastName, string email) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        #endregion

        #region TableColumns
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string? Company { get; set; }
        public string? CountryId { get; set; }
        public string? City { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? ZipPostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }

        #endregion

    }
}
