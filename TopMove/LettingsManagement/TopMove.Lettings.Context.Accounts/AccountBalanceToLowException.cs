using System;

namespace TopMove.Lettings.Context.Accounts
{
    public class AccountBalanceToLowException : Exception
    {
        public AccountBalanceToLowException(string message) : base(message) { }
    }
}