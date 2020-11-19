using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TOHEY.HRMS.Domain
{
    public abstract class EntityBase<TId> : IEntity<TId>
    {
        protected EntityBase(TId id)
        {
            Id = id;
        }

        [Key] public virtual TId Id { get; protected set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
