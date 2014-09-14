using System;
using RealEstate.Genie.Infrastructure.Domain.Interfaces;

namespace TopMove.Lettings.Events.Accounts
{
    public class ComplianceDocumentAddedEvent : IDomainEvent
    {
        public ComplianceDocumentAddedEvent(Guid id, Guid documentId)
        {
            Id = id;
            Document = documentId;
            
        }

        public Guid Document { get; private set; }

        public Guid Id { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
    }
}