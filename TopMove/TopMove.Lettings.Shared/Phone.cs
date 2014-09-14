using System;
using TopMove.Infrastructure;

namespace TopMove.Lettings.Shared
{
    public class Phone : ValueObject<Phone>
    {
        public int Id { get; set; }
        public Phone(string name, string number, bool isDefault = false)
        {
            Guard.ForNullOrEmpty(name,"name");
            Guard.ForNullOrEmpty(number,"number");
           
            Name = name;
            Number = number;
            IsDefault = isDefault;
        }
        public string Name { get; set; }
        public string Number { get; set; }

        public Guid ParentId { get; set; }
        public bool IsDefault { get; set; }
    }
}
