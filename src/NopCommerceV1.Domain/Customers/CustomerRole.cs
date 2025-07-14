using System;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace NopCommerceV1.Customers
{
    public class CustomerRole : FullAuditedEntity<Guid>
    {
        #region Ctor
        protected CustomerRole() { }

        public CustomerRole(Guid id, string name, bool active, bool isSystemRole, string? systemName, bool taxExempt, bool freeShipping = false)
            : base(id)
        {
            Name = name;
            Active = active;
            IsSystemRole = isSystemRole;
            SystemName = systemName;
            TaxExempt = taxExempt;
            FreeShipping = freeShipping;
        }
        #endregion

        #region Table Columns
        public string Name { get; set; }
        public string? SystemName { get; set; }
        public bool FreeShipping {  get; set; }

        public bool TaxExempt { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }

        #endregion

        #region Navigation Properies
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        #endregion
    }
}