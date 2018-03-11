using Hexagonal_FullProject.Application.Results;

namespace Hexagonal_FullProject.Application.Commands.Deposit
{
    public class DepositResult
    {
        public TransactionResult Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }
        public DepositResult()
        {

        }

        public DepositResult(TransactionResult transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
