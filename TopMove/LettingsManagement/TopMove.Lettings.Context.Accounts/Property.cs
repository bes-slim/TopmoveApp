using System;
using System.Collections.Generic;
using System.Linq;
using TopMove.Infrastructure;
using TopMove.Lettings.Events.Accounts;
using TopMove.Lettings.Shared;

namespace TopMove.Lettings.Context.Accounts
{
    public class Property : Entity<Guid>
    {
        private Balance _balance;
        private List<Document> _documents = new List<Document>(); 
        private List<Withdrawal> _withdrawals = new List<Withdrawal>();
        private List<Deposit> _deposits = new List<Deposit>();
        public Property(Guid accountId, Address address, IEnumerable<Withdrawal> withdrawals = null, IEnumerable<Deposit> deposits = null)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Address = address;
            if(withdrawals!=null) _withdrawals = withdrawals.ToList();
            if (deposits != null) _deposits = deposits.ToList();
        }

        public Address Address { get; private set; }

        public Guid AccountId { get; private set; }

        public Inventory Inventory { get; private set; }

        //Debit  Account
        // Credit Account
        // Balance
        public Balance Balance { get; set; }

        public virtual IEnumerable<Deposit> Deposits
        {
            get { return _deposits; }
            private set { _deposits = value.ToList(); }
        
        }

        public virtual IEnumerable<Withdrawal> Withdrawals { get { return _withdrawals; } } 
        public List<Document> Documents
        {
            get { return _documents; }
        }

        private void Guard()
        {

        }

        internal void Withdraw(Withdrawal withdrawal)
        {
            Guard();

            //IsBalanceHighEnough(amount);

            Balance = Balance.Withdrawl(withdrawal.Amount);

            _withdrawals.Add(withdrawal);

            DomainEvents.Raise(new CashWithdrawnEvent(this.Id, this.Balance, withdrawal.Amount));
        }

        internal void Deposit(Deposit deposit)
        {
            Guard();

            Balance = Balance.Deposit(deposit.Amount);

            DomainEvents.Raise(new CashDepositedEvent(this.Balance, deposit.Amount));
        }

        internal void AddComplianceDocument(Document document)
        {
            if(_documents.All(d => d.Id != document.Id))
                _documents.Add(document);

            DomainEvents.Raise(new ComplianceDocumentAddedEvent(Guid.NewGuid(), document.Id));
        }

        internal void AddInventory(Guid userId, Inventory inventory)
        {
            Inventory = inventory;

            DomainEvents.Raise(new PropertyInventoryCreatedEvent(userId, inventory.Id));
        }

    }
}

