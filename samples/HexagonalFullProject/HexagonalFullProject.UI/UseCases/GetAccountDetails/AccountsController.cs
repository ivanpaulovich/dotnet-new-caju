namespace HexagonalFullProject.UI.UseCases.GetAccountDetails
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using HexagonalFullProject.Application.Queries;
    using HexagonalFullProject.Application.Commands.Close;
    using HexagonalFullProject.Application.Commands.Withdraw;
    using HexagonalFullProject.Application.Commands.Deposit;
    using HexagonalFullProject.UI.Model;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountsQueries accountsQueries;

        public AccountsController(
            IAccountsQueries accountsQueries)
        {
            this.accountsQueries = accountsQueries;
        }

        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            var account = await accountsQueries.GetAccount(accountId);

            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            return new ObjectResult(new AccountDetailsModel(
                account.AccountId,
                account.CurrentBalance,
                transactions));
        }
    }
}
