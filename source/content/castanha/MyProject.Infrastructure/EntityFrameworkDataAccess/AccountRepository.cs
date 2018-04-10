namespace MyProject.Infrastructure.EntityFrameworkDataAccess
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;
    using MyProject.Domain.Accounts.Events;
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlClient;
    using MyProject.Application;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly Context context;

        public AccountRepository(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(OpenedDomainEvent domainEvent)
        {
            Account account = new Account();
            account.Apply(domainEvent);
            await context.Accounts.AddAsync(account);
            int affectedRows = await context.SaveChangesAsync();
        }

        public async Task Delete(ClosedDomainEvent domainEvent)
        {
            string deleteSQL =
                    @"DELETE FROM [Transaction] WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";

            var id = new SqlParameter("@Id", domainEvent.AggregateRootId);

            int affectedRows = await context.Database.ExecuteSqlCommandAsync(
                deleteSQL, id);
        }

        public async Task<Account> Get(Guid id)
        {
            var account = await context.Accounts.FindAsync(id);

            if (account == null)
                return null;

            await context.Entry(account)
                .Collection(i => i.Transactions)
                .LoadAsync();

            return account;
        }

        public async Task Update(DepositedDomainEvent domainEvent)
        {
            Account account = await context.Accounts.FindAsync(domainEvent.AggregateRootId);

            if (account == null)
                throw new AccountNotFoundException($"The account {domainEvent.AggregateRootId} does not exists or is already closed.");

            if (account.Version != domainEvent.Version)
                throw new TransactionConflictException(account, domainEvent);

            account.Apply(domainEvent);

            int affectedRows = await context.SaveChangesAsync();
        }

        public async Task Update(WithdrewDomainEvent domainEvent)
        {
            Account account = await context.Accounts.FindAsync(domainEvent.AggregateRootId);

            if (account == null)
                throw new AccountNotFoundException($"The account {domainEvent.AggregateRootId} does not exists or is already closed.");

            if (account.Version != domainEvent.Version)
                throw new TransactionConflictException(account, domainEvent);

            account.Apply(domainEvent);

            int affectedRows = await context.SaveChangesAsync();
        }
    }
}
