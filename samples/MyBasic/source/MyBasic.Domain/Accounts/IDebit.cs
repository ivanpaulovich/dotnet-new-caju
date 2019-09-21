namespace MyBasic.Domain.Accounts
{
    using MyBasic.Domain.ValueObjects;

    public interface IDebit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}