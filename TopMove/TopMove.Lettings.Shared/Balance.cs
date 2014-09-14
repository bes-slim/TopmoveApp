using TopMove.Infrastructure;

namespace TopMove.Lettings.Shared
{
    public class Balance : ValueObject<Balance>
    {
        private readonly Amount _amount;

        public Balance()
        {
            _amount = new Amount(0);
        }

        private Balance(decimal decimalAmount)
        {
            _amount = new Amount(decimalAmount);
        }

        public Balance Withdrawl(Amount amount)
        {
            return new Balance(_amount.Subtract(amount));
        }

        public Balance Deposit(Amount amount)
        {
            return new Balance(_amount.Add(amount));
        }

        public bool WithdrawlWillResultInNegativeBalance(Amount amount)
        {
            return new Amount(_amount).Subtract(amount).IsNegative();
        }

        public static implicit operator decimal(Balance balance)
        {
            return balance._amount;
        }

        public static implicit operator Balance(decimal decimalAmount)
        {
            return new Balance(decimalAmount);
        }
    }

}