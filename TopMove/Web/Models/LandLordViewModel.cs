using System;
using System.Collections.Generic;
using Web.Controllers;

namespace Web.Models
{
    public class LandLordViewModel
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<PhoneNumberViewModel> PhoneNumbers { get; set; }
        public AddressViewModel Address { get; set; }
        public IEnumerable<AddressViewModel> Properties { get; set; } 
    }
}