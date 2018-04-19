namespace MyProject.Application.UseCases.Deposit
{
    using MyProject.Application.Outputs;
    public class DepositOutput
    {
        public TransactionOutput Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }
        public DepositOutput()
        {

        }

        public DepositOutput(TransactionOutput transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
