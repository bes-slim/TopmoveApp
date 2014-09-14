using System;
using RealEstate.Genie.Infrastructure.Domain.Interfaces;

namespace TopMove.Lettings.Events.Accounts
{
    public class PropertyAddedToAccountEvent : IDomainEvent
    {
        public PropertyAddedToAccountEvent(Guid userId,  Guid propertyId)
        {
            UserId = userId;
            Property = propertyId;
            DateTimeEventOccurred = DateTime.UtcNow;
        }

        public Guid UserId { get; private set; }
        public Guid Property { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
    }
}