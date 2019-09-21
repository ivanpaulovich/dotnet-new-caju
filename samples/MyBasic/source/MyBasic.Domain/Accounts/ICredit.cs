namespace MyBasic.Domain.Accounts
{
    using MyBasic.Domain.ValueObjects;

    public interface ICredit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}