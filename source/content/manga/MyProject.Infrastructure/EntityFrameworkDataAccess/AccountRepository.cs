namespace MyProject.Infrastructure.EntityFrameworkDataAccess
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    internal class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly Context _context;

        public AccountRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Account account, Credit credit)
        {
            _context.Entry(credit).State = EntityState.Added;
            await _context.Accounts.AddAsync(account);
            int affectedRows = await _context.SaveChangesAsync();
        }

        public async Task Delete(Account account)
        {
            string deleteSQL =
                    @"DELETE FROM [Transaction] WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";

            var id = new SqlParameter("@Id", account.Id);

            int affectedRows = await _context.Database.ExecuteSqlCommandAsync(
                deleteSQL, id);
        }

        public async Task<Account> Get(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);

            string accountTransactionsOrdered =
                    @"SELECT * FROM [Transaction]
                      WHERE AccountId = @p0 
                      ORDER BY TransactionDate";

            IEnumerable<Transaction> transactions = await _context
                .Transactions
                .FromSql(accountTransactionsOrdered, id)
                .ToListAsync();

            Proxies.Account accountProxy = new Proxies.Account(account, transactions);
            return accountProxy;
        }

        public async Task Update(Account account, Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Added;

            int affectedRows = await _context.SaveChangesAsync();
        }
    }
}
