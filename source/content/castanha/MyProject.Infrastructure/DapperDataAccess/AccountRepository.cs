namespace MyProject.Infrastructure.DapperDataAccess
{
    using Dapper;
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MyProject.Domain.Accounts.Events;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly string connectionString;

        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task Add(OpenedDomainEvent domainEvent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string insertAccountSQL = "INSERT INTO Account (Id, CustomerId, Version) VALUES (@Id, @CustomerId, @Version)";

                DynamicParameters accountParameters = new DynamicParameters();
                accountParameters.Add("@id", domainEvent.AggregateRootId);
                accountParameters.Add("@customerId", domainEvent.CustomerId);
                accountParameters.Add("@version", domainEvent.Version);

                int accountRows = await db.ExecuteAsync(insertAccountSQL, accountParameters);

                string insertCreditSQL = "INSERT INTO [Transaction] (Id, Amount, TransactionDate, AccountId, TransactionType) " +
                    "VALUES (@Id, @Amount, @TransactionDate, @AccountId, @TransactionType)";

                DynamicParameters transactionParameters = new DynamicParameters();
                transactionParameters.Add("@id", domainEvent.TransactionId);
                transactionParameters.Add("@amount", domainEvent.TransactionAmount.Value);
                transactionParameters.Add("@transactionDate", domainEvent.TransactionDate);
                transactionParameters.Add("@accountId", domainEvent.AggregateRootId);
                transactionParameters.Add("@transactionType", 1);

                int debitRows = await db.ExecuteAsync(insertCreditSQL, transactionParameters);
            }
        }

        public async Task Delete(ClosedDomainEvent domainEvent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string deleteSQL =
                    @"DELETE FROM [Transaction] WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";

                DynamicParameters deleteParameters = new DynamicParameters();
                deleteParameters.Add("@id", domainEvent.AggregateRootId);

                int rowsAffected = await db.ExecuteAsync(deleteSQL, deleteParameters);
            }
        }

        public async Task<Account> Get(Guid id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string accountSQL = @"SELECT * FROM Account WHERE Id = @Id";
                Proxies.Account account = await db
                    .QueryFirstOrDefaultAsync<Proxies.Account>(accountSQL, new { id });
					
				if (account == null)
                    return null;

                var transactions = new List<Transaction>();

                string accountTransactionsOrdered =
                    @"SELECT * FROM [Transaction]
                      WHERE AccountId = @Id 
                      ORDER BY TransactionDate";

                using (var reader = db.ExecuteReader(accountTransactionsOrdered, new { id }))
                {
                    var debitParser = reader.GetRowParser<Debit>();
                    var creditParser = reader.GetRowParser<Credit>();

                    while (reader.Read())
                    {
                        Transaction transaction = null;

                        switch ((int)reader["TransactionType"])
                        {
                            case 0:
                                transaction = debitParser(reader);
                                break;
                            case 1:
                                transaction = creditParser(reader);
                                break;
                        }

                        transactions.Add(transaction);
                    }
                }

                account.SetTransactions(transactions);

                return account;
            }
        }

        public async Task Update(DepositedDomainEvent domainEvent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string updateAccountSQL = "UPDATE Account SET Version = @Version WHERE Id = @Id";
                DynamicParameters accountParameters = new DynamicParameters();
                accountParameters.Add("@id", domainEvent.AggregateRootId);
                accountParameters.Add("@version", domainEvent.Version);

                int rowsAffected = await db.ExecuteAsync(updateAccountSQL, accountParameters);

                string insertCreditSQL = "INSERT INTO [Transaction] (Id, Amount, TransactionDate, AccountId, TransactionType) " +
                    "VALUES (@Id, @Amount, @TransactionDate, @AccountId, @TransactionType)";

                DynamicParameters transactionParameters = new DynamicParameters();
                transactionParameters.Add("@id", domainEvent.TransactionId);
                transactionParameters.Add("@amount", domainEvent.TransactionAmount.Value);
                transactionParameters.Add("@transactionDate", domainEvent.TransactionDate);
                transactionParameters.Add("@accountId", domainEvent.AggregateRootId);
                transactionParameters.Add("@transactionType", 1);

                int creditRows = await db.ExecuteAsync(insertCreditSQL, transactionParameters);
            }
        }

        public async Task Update(WithdrewDomainEvent domainEvent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string updateAccountSQL = "UPDATE Account SET Version = @Version WHERE Id = @Id";
                DynamicParameters accountParameters = new DynamicParameters();
                accountParameters.Add("@id", domainEvent.AggregateRootId);
                accountParameters.Add("@version", domainEvent.Version);

                int rowsAffected = await db.ExecuteAsync(updateAccountSQL, accountParameters);

                string insertCreditSQL = "INSERT INTO [Transaction] (Id, Amount, TransactionDate, AccountId, TransactionType) " +
                    "VALUES (@Id, @Amount, @TransactionDate, @AccountId, @TransactionType)";

                DynamicParameters transactionParameters = new DynamicParameters();
                transactionParameters.Add("@id", domainEvent.TransactionId);
                transactionParameters.Add("@amount", domainEvent.TransactionAmount.Value);
                transactionParameters.Add("@transactionDate", domainEvent.TransactionDate);
                transactionParameters.Add("@accountId", domainEvent.AggregateRootId);
                transactionParameters.Add("@transactionType", 0);

                int debitRows = await db.ExecuteAsync(insertCreditSQL, transactionParameters);
            }
        }
    }
}
