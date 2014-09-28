using System;

namespace Web.Models
{
    public class DocumentViewModel
    {
        public DocumentViewModel(Guid id, Guid userId, Guid propertyId, string issuer, DateTime validFrom, DateTime validTill, string link)
        {
            Id = id;
            AddedBy = userId;
            Issuer = issuer;
            ValidFrom = validFrom;
            VaidTill = validTill;
            PropertyId = propertyId;
            Link = link;
        }

        public Guid Id { get; set; }

        public string Issuer { get;  set; }
        public DateTime ValidFrom { get; set; }
        public DateTime VaidTill { get; set; }

        public Guid AddedBy { get; set; }
        public string Notes { get; set; }
        public Guid PropertyId { get;  set; }
        
        /// <summary>
        /// link to document location
        /// </summary>
        public string Link { get; set; }

        public bool Validated { get; set; }
    }
}