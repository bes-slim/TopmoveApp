using TopMove.Infrastructure;

namespace TopMove.Lettings.Shared
{
    public class Address : ValueObject<Address>
    {
        public Address(string name, string houseNameNumber, string addressLine1, string town, string city, string county, string country, string postalCode)
        {
            Guard.ForNullOrEmpty(name,"name");
            Guard.ForNullOrEmpty(houseNameNumber,"houseNameNumber");
            Guard.ForNullOrEmpty(addressLine1,"addressLine1");
            Guard.ForNullOrEmpty(town,"town");
            Guard.ForNullOrEmpty(postalCode,"postalCode");

            Name = name;
            HouseNameNumber = houseNameNumber;
            AddressLine1 = addressLine1;
            Town = town;
            County = county;
            Country = country;
            City = city;
            PostCode = postalCode;
        }

        public string Name { get; set; }
        public string HouseNameNumber { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        public string Town { get; set; }

        public string County { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
        public string PostCode { get; set; }
    }
}