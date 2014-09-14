using System;
using RealEstate.Genie.Infrastructure.Domain.Interfaces;

namespace TopMove.Lettings.Events.Accounts
{
    public class AccountCreatedEvent : IDomainEvent
    {
        public AccountCreatedEvent(Guid userId, Guid accountId)
        {
            Id = Guid.NewGuid();
            DateTimeEventOccurred = DateTime.UtcNow;
            CreatedBy = userId;
            AccountId = accountId;
        }

        public Guid AccountId { get; private set; }

        public Guid CreatedBy { get; private set; }
        public Guid Id { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
    }
}