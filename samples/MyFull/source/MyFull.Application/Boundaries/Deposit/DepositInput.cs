namespace MyFull.Application.Boundaries.Deposit
{
    using System;
    using MyFull.Application.Exceptions;
    using MyFull.Domain.ValueObjects;

    public sealed class DepositInput
    {
        public Guid AccountId { get; }
        public PositiveMoney Amount { get; }

        public DepositInput(Guid accountId, PositiveMoney amount)
        {
            if (accountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(accountId)} cannot be empty.");
            }

            if (amount == null)
            {
                throw new InputValidationException($"{nameof(amount)} cannot be null.");
            }

            this.AccountId = accountId;
            this.Amount = amount;
        }
    }
}