using System;
using RealEstate.Genie.Infrastructure.Domain.Interfaces;

namespace TopMove.Lettings.Events.Accounts
{
    public class CashDepositedEvent : IDomainEvent
    {
        public decimal Balance { get; private set; }
        public decimal Amount { get; private set; }

        public CashDepositedEvent( decimal balance, decimal amount)
        {
            Balance = balance;
            Amount = amount;
            DateTimeEventOccurred = DateTime.UtcNow;
        }
       
        public DateTime DateTimeEventOccurred { get; private set; }
    }
}