namespace MyFull.Application.Boundaries.Deposit
{
    public interface IOutputHandler : IErrorHandler
    {
        void Default(DepositOutput depositOutput);
    }
}