namespace MyFull.Application.Boundaries.CloseAccount
{
    using System;
    using MyFull.Domain.Accounts;

    public sealed class CloseAccountOutput
    {
        public Guid AccountId { get; }

        public CloseAccountOutput(IAccount account)
        {
            AccountId = account.Id;
        }
    }
}