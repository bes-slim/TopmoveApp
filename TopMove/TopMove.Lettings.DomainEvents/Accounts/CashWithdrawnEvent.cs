using System;
using RealEstate.Genie.Infrastructure.Domain.Interfaces;
using TopMove.Lettings.Shared;

namespace TopMove.Lettings.Events.Accounts
{
    public class CashWithdrawnEvent : IDomainEvent
    {
        public CashWithdrawnEvent(Guid id, Balance balance, Amount amount)
        {

            Id = id;
            DateTimeEventOccurred = DateTime.UtcNow;
            Balance = balance;
            Amount = amount;
        }

        public Guid Id { get; private set; }

        public decimal Balance { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
        
    }
}