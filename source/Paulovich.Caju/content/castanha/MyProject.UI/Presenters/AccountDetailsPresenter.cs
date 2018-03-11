namespace MyProject.UI.Presenters
{
    using MyProject.Application;
    using MyProject.Application.Outputs;
    using MyProject.UI.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class AccountDetailsPresenter : IOutputBoundary<AccountOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public AccountOutput Response { get; private set; }

        public void Populate(AccountOutput response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in response.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            ViewModel = new ObjectResult(new AccountDetailsModel(
                response.AccountId,
                response.CurrentBalance,
                transactions));
        }
    }
}
