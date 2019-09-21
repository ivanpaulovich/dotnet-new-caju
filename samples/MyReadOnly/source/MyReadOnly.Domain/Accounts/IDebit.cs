namespace MyReadOnly.Domain.Accounts
{
    using MyReadOnly.Domain.ValueObjects;

    public interface IDebit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}