using System;
using TopMove.Infrastructure;

namespace TopMove.Lettings.Shared
{
    public class Withdrawal : Entity<int>
    {
        public Withdrawal(Amount amount, DateTime withDrawn, string reference, string additionalNotes = null)
        {
            Amount = amount;
            WithDrawn = withDrawn;
            Reference = reference;
            AdditionalNotes = additionalNotes ?? string.Empty;
        }

        public Guid PropertyId { get; private set; }

        public Amount Amount { get; private set; }
        public DateTime WithDrawn { get; private set; }
        public string Reference { get; private set; }
        public string AdditionalNotes { get; private set; }
    }

    public class Deposit : Entity<int>
        {
            public Deposit(Amount amount, DateTime deposited, string reference, string additionalNotes = null,
                bool isRent = true)
            {
                Amount = amount;
                Deposited = deposited;
                Reference = reference;
                AdditionalNotes = additionalNotes ?? string.Empty;
                IsRent = isRent;
            }

            public Guid PropertyId { get; private set; }

            public Amount Amount { get; private set; }
            public DateTime Deposited { get; private set; }
            public string Reference { get; private set; }

            public bool IsRent { get; set; }
            public string AdditionalNotes { get; private set; }
        }
    }
