namespace MyProject.Infrastructure.MongoDataAccess
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;
    using MyProject.Domain.Accounts.Events;
    using MyProject.Application;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly AccountBalanceContext mongoContext;

        public AccountRepository(AccountBalanceContext mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task Add(OpenedDomainEvent domainEvent)
        {
            Account account = new Account();
            account.Apply(domainEvent);

            await mongoContext.Accounts.InsertOneAsync(account);
        }

        public async Task Delete(ClosedDomainEvent domainEvent)
        {
            Account account = await mongoContext
                .Accounts
                .Find(e => e.Id == domainEvent.AggregateRootId)
                .SingleOrDefaultAsync();

            if (account == null)
                throw new AccountNotFoundException($"The account {domainEvent.AggregateRootId} does not exists or is already closed.");

            if (account.Version != domainEvent.Version)
                throw new TransactionConflictException(account, domainEvent);

            await mongoContext.Accounts.DeleteOneAsync(e => e.Id == account.Id);
        }

        public async Task<Account> Get(Guid id)
        {
            return await mongoContext
                .Accounts
                .Find(e => e.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task Update(DepositedDomainEvent domainEvent)
        {
            Account account = await mongoContext
                .Accounts
                .Find(e => e.Id == domainEvent.AggregateRootId)
                .SingleOrDefaultAsync();

            if (account == null)
                throw new AccountNotFoundException($"The account {domainEvent.AggregateRootId} does not exists or is already closed.");

            if (account.Version != domainEvent.Version)
                throw new TransactionConflictException(account, domainEvent);

            account.Apply(domainEvent);

            await mongoContext.Accounts.ReplaceOneAsync(e => e.Id == account.Id, account);
        }

        public async Task Update(WithdrewDomainEvent domainEvent)
        {
            Account account = await mongoContext
                .Accounts
                .Find(e => e.Id == domainEvent.AggregateRootId)
                .SingleOrDefaultAsync();

            if (account == null)
                throw new AccountNotFoundException($"The account {domainEvent.AggregateRootId} does not exists or is already closed.");

            if (account.Version != domainEvent.Version)
                throw new TransactionConflictException(account, domainEvent);

            account.Apply(domainEvent);

            await mongoContext.Accounts.ReplaceOneAsync(e => e.Id == account.Id, account);
        }
    }
}
