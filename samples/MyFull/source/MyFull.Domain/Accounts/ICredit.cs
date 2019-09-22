namespace MyFull.Domain.Accounts
{
    using MyFull.Domain.ValueObjects;

    public interface ICredit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}