using System;

namespace TopMove.Lettings.Context.Accounts
{
    public class DuplicateAddressException : Exception
    {
        public DuplicateAddressException(string message): base(message) { }
    }
}