using System;
using TopMove.Infrastructure;

namespace TopMove.Lettings.Context.Accounts
{
    public class Document : Entity<Guid>
    {
        public Document(Guid id, Guid userId, Guid propertyId, string issuer, DateTime validFrom, DateTime validTill, string link)
        {
            Id = id;
            AddedBy = userId;
            Issuer = issuer;
            ValidFrom = validFrom;
            VaidTill = validTill;
            PropertyId = propertyId;
            Link = link;
        }
        public string Issuer { get; private set; }
        public DateTime ValidFrom { get; private set; }
        public DateTime VaidTill { get; set; }

        public Guid AddedBy { get; set; }
        public string Notes { get; set; }
        public Guid PropertyId { get; private set; }
        
        /// <summary>
        /// link to document location
        /// </summary>
        public string Link { get; set; }

        public bool Validated { get; set; }
       
    }
}