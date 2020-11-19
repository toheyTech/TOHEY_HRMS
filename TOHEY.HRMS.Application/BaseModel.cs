using System;
using System.Collections.Generic;
using System.Text;

namespace HRMS.Application
{
    public abstract class BaseModel : IDbEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string LastModifiedBy { get; set; }
        public virtual DateTime? LastModified { get; set; }
    }
}
