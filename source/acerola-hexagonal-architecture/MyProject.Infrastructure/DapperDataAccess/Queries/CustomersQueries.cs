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
    using MyProject.Domain.Customers;

    public class CustomersQueries : ICustomersQueries
    {
        private readonly string connectionString;
        private readonly IResultConverter resultConverter;

        public CustomersQueries(string connectionString, IResultConverter resultConverter)
        {
            this.connectionString = connectionString;
            this.resultConverter = resultConverter;
        }

        public async Task<CustomerResult> GetCustomer(Guid id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string customerSQL = "SELECT * FROM Customer WHERE Id = @Id";
                Proxies.Customer customer = await db
                    .QueryFirstOrDefaultAsync<Proxies.Customer>(customerSQL, new { id });

                if (customer == null)
                    return null;

                string accountSQL = "SELECT * FROM Account WHERE CustomerId = @Id";
                var accounts = await db
                    .QueryAsync<Proxies.Account>(accountSQL, new { id });

                List<AccountResult> accountsResult = new List<AccountResult>();

                foreach (var account in accounts)
                {
                    if (account == null)
                        throw new AccountNotFoundException($"The account {account.Id} does not exists or is not processed yet.");

                    var transactions = new List<Transaction>();

                    string accountTransactionsOrdered =
                        @"SELECT * FROM [Transaction]
                          WHERE AccountId = @Id 
                          ORDER BY TransactionDate";

                    using (var reader = db.ExecuteReader(accountTransactionsOrdered, new { account.Id }))
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

                    if (account != null)
                    {
                        AccountResult accountOutput = resultConverter.Map<AccountResult>(account);
                        accountsResult.Add(accountOutput);
                    }
                }

                CustomerResult customerResult = resultConverter.Map<CustomerResult>(customer);

                customerResult = new CustomerResult(
                    customerResult.CustomerId,
                    customerResult.Personnummer,
                    customerResult.Name,
                    accountsResult);

                return customerResult;
            }
        }
    }
}
