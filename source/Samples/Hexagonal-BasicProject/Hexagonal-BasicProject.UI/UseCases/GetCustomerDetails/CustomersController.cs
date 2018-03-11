namespace Hexagonal_BasicProject.UI.UseCases.GetCustomerDetails
{
    using Hexagonal_BasicProject.Application.Queries;
    using Hexagonal_BasicProject.Application.Results;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Hexagonal_BasicProject.Application.Commands.Register;
    using Hexagonal_BasicProject.UI.Model;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomersQueries customersQueries;

        public CustomersController(ICustomersQueries customersQueries)
        {
            this.customersQueries = customersQueries;
        }

        /// <summary>
        /// Get a Customer details 
        /// </summary>
        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            CustomerResult customer = await customersQueries.GetCustomer(customerId);

            if (customer == null)
            {
                return new NoContentResult();
            }

            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();

            foreach (var account in customer.Accounts)
            {
                List<TransactionModel> transactions = new List<TransactionModel>();

                foreach (var item in account.Transactions)
                {
                    var transaction = new TransactionModel(
                        item.Amount,
                        item.Description,
                        item.TransactionDate);

                    transactions.Add(transaction);
                }

                accounts.Add(new AccountDetailsModel(
                    account.AccountId,
                    account.CurrentBalance,
                    transactions));
            }

            CustomerDetailsModel model = new CustomerDetailsModel(
                customer.CustomerId,
                customer.Personnummer,
                customer.Name,
                accounts
            );

            return new ObjectResult(model);
        }
    }
}
