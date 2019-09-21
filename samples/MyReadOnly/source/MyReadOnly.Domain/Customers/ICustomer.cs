namespace MyReadOnly.Domain.Customers
{
    using MyReadOnly.Domain.Accounts;

    public interface ICustomer : IAggregateRoot
    {
        AccountCollection Accounts { get; }
        void Register(IAccount account);
    }
}