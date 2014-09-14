using System;
using TopMove.Infrastructure;

namespace TopMove.Lettings.Shared
{
    public class Name : ValueObject<Name>
    {
        public Name(string title, string firstName, string initial, string surname)
        {
            Title = title;
            FirstName = firstName;
            Initial = initial;
            Surname = surname;
        }

       
        public string Title { get; private set; }
        public string Initial { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
    }
}