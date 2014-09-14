using System;
using RealEstate.Genie.Infrastructure.Domain.Interfaces;

namespace TopMove.Lettings.Events.Accounts
{
    public class PropertyInventoryCreatedEvent : IDomainEvent
    {
        public PropertyInventoryCreatedEvent(Guid userId,  Guid inventory)
        {
            UserId = userId;
            DateTimeEventOccurred = DateTime.UtcNow;
            Inventory = inventory;
            
        }

        public Guid Inventory { get; private set; }

        public Guid UserId { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
    }
}