namespace MyReadOnly.Infrastructure.InMemoryDataAccess
{
    using System.Collections.ObjectModel;
    using MyReadOnly.Application.Boundaries.Transfer;

    public sealed class TransferPresenter : IOutputPort
    {
        public Collection<string> Errors { get; }
        public Collection<TransferOutput> Transfers { get; }

        public TransferPresenter()
        {
            Errors = new Collection<string>();
            Transfers = new Collection<Application.Boundaries.Transfer.TransferOutput>();
        }

        public void Error(string message)
        {
            Errors.Add(message);
        }

        public void Default(TransferOutput output)
        {
            Transfers.Add(output);
        }
    }
}