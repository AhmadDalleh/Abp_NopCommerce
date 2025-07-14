using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace NopCommerceV1.Customers
{
    public class NewsLetterSubscription : FullAuditedEntity<Guid>
    {
        #region Ctor
        protected NewsLetterSubscription()
        {
        }

        public NewsLetterSubscription(Guid id, string email, bool active, DateTime createdOnUtc) : base(id)
        {
            Email = email;
            Active = active;
            CreatedOnUtc = createdOnUtc;
        }

        #endregion

        #region Table Columns
        public string Email { get; set; }
        public Guid? CustomerId { get; set; }

        public Guid? StoreId { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        #endregion

        #region Navigation Propeties
        public virtual Customer? Customer { get; set; }

        #endregion
    }
}
