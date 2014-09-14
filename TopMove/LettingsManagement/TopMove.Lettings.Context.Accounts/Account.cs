using System;
using System.Collections.Generic;
using System.Linq;
using TopMove.Infrastructure;
using TopMove.Lettings.Events.Accounts;
using TopMove.Lettings.Shared;

namespace TopMove.Lettings.Context.Accounts
{
    public class Account : Entity<Guid>
    {
        private Balance _balance;
        private Guid _landLord;
        private List<Property> _properties = new List<Property>(); 
        public Account(Guid userId, Guid id, Guid landLord, Address propertyAddress)
        {
            if (id == Guid.Empty)
                id = Guid.NewGuid();
            Id = id;
            if(landLord==null) throw new ArgumentNullException("landLord");
            if(propertyAddress ==null) throw new ArgumentNullException("propertyAddress");
            
            _landLord = landLord;
            CreatedBy = userId;
            

            DomainEvents.Raise(new AccountCreatedEvent(userId,this.Id));
        }
        public Guid CreatedBy { get; private set; }

        public Guid LandLord { get; private set; }

        public IEnumerable<Property> Properties { get { return _properties; } } 
 
        public void Deposit(Guid propertyId, Deposit deposit)
        {
            Guard();

            ThrowIfPropertyDoesNotExist(propertyId);

            var property = GetProperty(propertyId);
            
            property.Deposit(deposit);

        }

        private Property GetProperty(Guid propertyId)
        {
            return _properties.Single(p => p.Id == propertyId);
        }

        private void ThrowIfPropertyDoesNotExist(Guid propertyId)
        {
            if (!ProperyExists(propertyId))
                throw new InvalidOperationException("no property with that id exists");
        }

        private bool ProperyExists(Guid propertyId)
        {
            return _properties.Any(p => p.Id == propertyId);
        }
        public void AddProperty(Guid userId, Property property)
        {
            if(!property.AccountId.Equals(property.AccountId))
                throw new InvalidOperationException("invalid account id for this property");

            if (property.Address.Equals(property.Address))
                throw new DuplicateAddressException("cannot add a property with exact same address");
             
            
            _properties.Add(property);

            DomainEvents.Raise(new PropertyAddedToAccountEvent(userId,property.Id ));
        }

        public void AddComplianceDocument(Document document)
        {
            ThrowIfPropertyDoesNotExist(document.PropertyId);

            var property = GetProperty(document.PropertyId);

            property.AddComplianceDocument(document);
        }

        public void AddInventory(Guid userId,Inventory inventory)
        {
            ThrowIfPropertyDoesNotExist(inventory.PropertyId);

            var property = GetProperty(inventory.PropertyId);

            property.AddInventory(userId,inventory);
        }

        //public void EditInventory(Guid userId, Guid propertyId, InventoryItem inventoryItem)
        //{
        //    ThrowIfPropertyDoesNotExist(propertyId);

        //    var property = GetProperty(propertyId);

        //    property.Inventory.EditInventoryItem(inventoryItem);

        //    DomainEvents.Raise(new InventoryEditedEvent(Guid.NewGuid(), userId,propertyId, inventoryItem));
        //}

        public void Withdraw(Guid propertyId,  Withdrawal withdrawal)
        {
            ThrowIfPropertyDoesNotExist(propertyId);

            var property = GetProperty(propertyId);

            property.Withdraw(withdrawal);
        }

        private void IsBalanceHighEnough(Amount amount)
        {
            if (_balance.WithdrawlWillResultInNegativeBalance(amount))
                throw new AccountBalanceToLowException(string.Format("The amount {0:C} is larger than your current balance {1:C}", (decimal)amount, (decimal)_balance));
        }

        public void CreditAccount() { }

        private void Guard()
        {
            
        }
    }
}