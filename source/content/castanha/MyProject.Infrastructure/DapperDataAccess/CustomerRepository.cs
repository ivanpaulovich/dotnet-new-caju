namespace MyProject.Infrastructure.DapperDataAccess
{
    using Dapper;
    using MyProject.Application.Repositories;
    using MyProject.Domain.Customers;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MyProject.Domain.Customers.Events;

    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly string connectionString;

        public CustomerReadOnlyRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task Add(RegisteredDomainEvent domainEvent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string insertCustomerSQL = "INSERT INTO Customer (Id, Name, PIN, Version) VALUES (@Id, @Name, @PIN, @Version)";
                DynamicParameters customerParameters = new DynamicParameters();
                customerParameters.Add("@id", domainEvent.AggregateRootId);
                customerParameters.Add("@name", domainEvent.CustomerName.Text, DbType.AnsiString);
                customerParameters.Add("@pin", domainEvent.CustomerPIN.Text, DbType.AnsiString);
                customerParameters.Add("@version", domainEvent.Version);

                int customerRows = await db.ExecuteAsync(insertCustomerSQL, customerParameters);
            }
        }

        public async Task<Customer> Get(Guid id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string customerSQL = "SELECT * FROM Customer WHERE Id = @Id";
                Proxies.Customer customer = await db
                    .QueryFirstOrDefaultAsync<Proxies.Customer>(customerSQL, new { id });

                string accountSQL = "SELECT * FROM Account WHERE CustomerId = @Id";
                IEnumerable<Guid> accounts = await db
                    .QueryAsync<Guid>(accountSQL, new { id });

                customer.SetAccounts(accounts);

                return customer;
            }
        }
    }
}
