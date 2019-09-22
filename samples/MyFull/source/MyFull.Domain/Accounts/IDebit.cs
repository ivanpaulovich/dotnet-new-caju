namespace MyFull.Domain.Accounts
{
    using MyFull.Domain.ValueObjects;

    public interface IDebit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}