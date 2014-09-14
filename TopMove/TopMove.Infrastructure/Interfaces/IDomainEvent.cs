using System;


namespace RealEstate.Genie.Infrastructure.Domain.Interfaces
{
    public interface IDomainEvent
    {
        //Guid Id { get; }
        DateTime DateTimeEventOccurred { get; }
    }
}
