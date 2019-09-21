namespace MyReadOnly.Domain.Accounts
{
    using MyReadOnly.Domain.ValueObjects;

    public interface ICredit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}