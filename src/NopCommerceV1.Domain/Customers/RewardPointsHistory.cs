using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace NopCommerceV1.Customers
{
    public class RewardPointsHistory : FullAuditedEntity<Guid>
    {

        #region Ctor
        protected RewardPointsHistory()
        {
        }

        public RewardPointsHistory(Guid id, Guid customerId = default, int points = 0, string message = null, DateTime createdOnUtc = default) : base(id)
        {
            CustomerId = customerId;
            Points = points;
            Message = message;
            CreatedOnUtc = createdOnUtc;
        }

        #endregion

        #region Table Columns
        public Guid CustomerId { get; set; }
        public int Points { get; set; }

        public string Message {  get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? EndDateOnUtc { get; set; }
        public Guid UseWithOrderId { get; set; }

        #endregion

        #region Navigation Property
        public virtual Customer Customer { get; set; }

        #endregion
    }
}
