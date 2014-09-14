using System;
using RealEstate.Genie.Infrastructure.Domain.Interfaces;
using TopMove.Lettings.Shared;

namespace TopMove.Lettings.Events.Accounts
{
    public class LandLordAddressChangedEvent : IDomainEvent
    {
        public LandLordAddressChangedEvent(Guid userId, Guid landLordId, Address address)
        {
           
            ComittedBy = userId;
            LandLordId = landLordId;
            ChangedAddress = address;
            DateTimeEventOccurred = DateTime.Now;
        }

        public Guid LandLordId { get; private set; }
        public Guid ComittedBy { get; private set; }
        public Address ChangedAddress { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
    }
}