namespace MyProject.Infrastructure.MongoDataAccess.Queries
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MyProject.Application;
    using MyProject.Application.Queries;
    using MyProject.Application.Results;
    using MyProject.Domain.Customers;
    using MyProject.Infrastructure.EntityFrameworkDataAccess;

    public class CustomersQueries : ICustomersQueries
    {
        private readonly Context context;
        private readonly IResultConverter resultConverter;

        public CustomersQueries(Context context, IResultConverter resultConverter)
        {
            this.context = context;
            this.resultConverter = resultConverter;
        }

        public async Task<CustomerResult> GetCustomer(Guid id)
        {
            Customer customer = await context.Customers.FindAsync(id);
            var accounts = await context
                .Accounts
                .Where(p => p.CustomerId == id)
                .ToListAsync();

            if (customer == null)
                throw new CustomerNotFoundException($"The customer {id} does not exists or is not processed yet.");

            List<AccountResult> accountsResult = new List<AccountResult>();

            foreach (var account in accounts)
            {
                await context.Entry(account)
                    .Collection(i => i.Transactions)
                    .LoadAsync();

                if (account == null)
                    throw new CustomerNotFoundException($"The account {account.Id} does not exists or is not processed yet.");

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
