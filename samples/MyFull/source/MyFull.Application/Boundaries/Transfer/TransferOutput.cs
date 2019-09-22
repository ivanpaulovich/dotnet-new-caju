namespace MyFull.Application.Boundaries.Transfer
{
    using System;
    using MyFull.Domain.Accounts;
    using MyFull.Domain.ValueObjects;

    public sealed class TransferOutput
    {
        public Transaction Transaction { get; }
        public decimal UpdatedBalance { get; }

        public TransferOutput(IDebit debit, Money updatedBalance, Guid originAccountId, Guid destinationAccountId)
        {
            Debit debitEntity = (Debit) debit;

            Transaction = new Transaction(
                originAccountId,
                destinationAccountId,
                debitEntity.Description,
                debitEntity.Amount
                .ToMoney()
                .ToDecimal(),
                debitEntity.TransactionDate);

            UpdatedBalance = updatedBalance.ToDecimal();
        }
    }
}