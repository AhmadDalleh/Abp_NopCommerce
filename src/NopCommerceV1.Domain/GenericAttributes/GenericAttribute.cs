using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace NopCommerceV1.GenericAttributes
{

    public class GenericAttribute : FullAuditedEntity<Guid>
    {
        #region Ctor
        protected GenericAttribute() { }

        public GenericAttribute(Guid id,Guid entityId, string keyGroup, string key , string? value )
            :base(id)
        {
            EntityId = entityId;
            KeyGroup = keyGroup;
            this.key = key;
            Value = value;
        }
        #endregion


        #region Table Columns
        public Guid EntityId {  get; set; }
        public string KeyGroup { get; set; } = string.Empty;
        public string key { get; set; } = string.Empty;
       public string? Value { get; set; }
       #endregion
    }
}
