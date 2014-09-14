using System;
using System.Collections.Generic;
using TopMove.Infrastructure;
using TopMove.Lettings.Shared;

namespace TopMove.Lettings.Context.Accounts
{
    public class Tenant : Entity<Guid>
    {
        public Name Name { get; set; }
        public Guid PropertyId { get; set; }
        public IEnumerable<Phone> ContactPhones { get; private set; }
        public DateTime Created { get; private set; }
        
    }
}