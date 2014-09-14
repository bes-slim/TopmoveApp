using System;
using RealEstate.Genie.Infrastructure.Domain.Interfaces;

namespace TopMove.Lettings.Events.Accounts
{
    public class LandLordCreatedEvent : IDomainEvent
    {
        public LandLordCreatedEvent(Guid landlordId) : this()
        {
            LandLordCreated = landlordId;
        }

        public LandLordCreatedEvent()
        {
            this.Id = Guid.NewGuid();
            DateTimeEventOccurred = DateTime.Now;
        }

        public Guid LandLordCreated { get; set; }

        public Guid Id { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
    }
}