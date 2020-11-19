using System;

namespace TOHEY.HRMS.Domain
{
    public class Person<TId> : EntityBase<TId>, IDomainEntity where TId : class, new()
    {
        public override TId Id { get => base.Id; protected set => base.Id = value; }        
        public string BioID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Gender1 { get; set; }
        public Person(TId id): base(id)
        {
            Id = Guid.NewGuid() as TId;
        }
    }
}
