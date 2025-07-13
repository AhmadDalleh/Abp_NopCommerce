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

        public CustomerRole(Guid id, string name, bool isActive, bool isSystemRole, string? systemName)
            : base(id)
        {
            Name = name;
            IsActive = isActive;
            IsSystemRole = isSystemRole;
            SystemName = systemName;
        }
        #endregion

        #region Table Columns
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystemRole { get; set; }
        public string? SystemName { get; set; }

        #endregion

        #region Navigation Properies
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        #endregion
    }
}