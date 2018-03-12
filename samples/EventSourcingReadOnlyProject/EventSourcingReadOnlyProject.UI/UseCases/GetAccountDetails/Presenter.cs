namespace EventSourcingReadOnlyProject.UI.UseCases.GetAccountDetails
{
    using EventSourcingReadOnlyProject.Application;
    using EventSourcingReadOnlyProject.Application.Outputs;
    using EventSourcingReadOnlyProject.UI.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class Presenter : IOutputBoundary<AccountOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public AccountOutput Output { get; private set; }

        public void Populate(AccountOutput output)
        {
            Output = output;

            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in output.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            ViewModel = new ObjectResult(new AccountDetailsModel(
                output.AccountId,
                output.CurrentBalance,
                transactions));
        }
    }
}
