using System;
using System.Collections.Generic;
using System.Linq;
using TopMove.Infrastructure;
using TopMove.Lettings.Events.Accounts;
using TopMove.Lettings.Shared;

namespace TopMove.Lettings.Context.Accounts
{
    public class LandLord : Entity<Guid>
    {
        private List<Phone> _phones = new List<Phone>();
        private List<Account> _accounts = new List<Account>();

        internal LandLord()
        {
            
        }

        public LandLord(Guid id, Name name, Phone contactNumber, Address contactAddress)
        {
            if (id == Guid.Empty)
                id = Guid.NewGuid();
            Id = id;
            Name = name;

            _phones.Add(contactNumber);
            ContactAddress = contactAddress;
            DomainEvents.Raise(new LandLordCreatedEvent(this.Id));
        }

        public Name Name { get;  set; }

        public IEnumerable<Phone> ContactNumbers { get  { return _phones; } }

        public Address ContactAddress { get; set; }

        public void ChangeContactAddress(Guid userId,  Address address)
        {
            this.ContactAddress = address;
            DomainEvents.Raise(new LandLordAddressChangedEvent(userId, this.Id, address));
        }

        public void AddAccount(Account account)
        {
            //if(_accounts.All(a => a.Id == account.Id))
                
        }

        public void AddContactPhoneNumber(Guid userGuid, Phone contactNumber)
        {
            if (!this._phones.Any(p => p.Equals(contactNumber)))
                _phones.Add(contactNumber);
        }
 
    }
}