using System;
using Web.Controllers;

namespace Web.Models
{
    public class PropertyViewModel
    {
        public int Id { get; set; }
        public AddressViewModel Address { get; set; }
        public Guid LandLordId { get; set; } 
    }
}