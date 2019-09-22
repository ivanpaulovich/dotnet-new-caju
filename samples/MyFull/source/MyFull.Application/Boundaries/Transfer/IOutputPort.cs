namespace MyFull.Application.Boundaries.Transfer
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(TransferOutput transferOutput);
    }
}