namespace MyProject.Infrastructure.DapperDataAccess.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using MyProject.Application;
    using MyProject.Application.Queries;
    using MyProject.Application.Results;
    using MyProject.Domain.Accounts;

    public class AccountsQueries : IAccountsQueries
    {
        private readonly string connectionString;
        private readonly IResultConverter resultConverter;

        public AccountsQueries(string connectionString, IResultConverter resultConverter)
        {
            this.connectionString = connectionString;
            this.resultConverter = resultConverter;
        }

        public async Task<AccountResult> GetAccount(Guid id)
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
                AccountResult accountResult = this.resultConverter.Map<AccountResult>(account);

                return accountResult;
            }
        }
    }
}
