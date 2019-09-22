namespace MyFull.Application.Boundaries.Deposit
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(DepositOutput depositOutput);
    }
}