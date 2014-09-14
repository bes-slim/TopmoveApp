using System.Data.Entity;
using TopMove.Lettings.Context.Accounts;
using TopMove.Lettings.Shared;

namespace TopMove.Lettings.Accounts.Data
{
    public class AccountsContext : DbContext
    {
        public AccountsContext()
            :base("AccountsContext")
        {
            
        }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<LandLord> LandLords { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Withdrawal> Withdrawals { get; set; }

        //public DbSet<Address> Addresses { get; set; }

        //public DbSet<PostCode> PostCodes { get; set; }

       public DbSet<Deposit> Deposits { get; set; }

       public DbSet<Phone> Phones { get; set; }
       
    }
}
