namespace MyReadOnly.Infrastructure.InMemoryDataAccess
{
    using System.Collections.ObjectModel;
    using MyReadOnly.Application.Boundaries.Deposit;

    public sealed class DepositPresenter : IOutputPort
    {
        public Collection<string> Errors { get; }
        public Collection<DepositOutput> Deposits { get; }

        public DepositPresenter()
        {
            Errors = new Collection<string>();
            Deposits = new Collection<DepositOutput>();
        }

        public void Error(string message)
        {
            Errors.Add(message);
        }

        public void Default(DepositOutput output)
        {
            Deposits.Add(output);
        }
    }
}