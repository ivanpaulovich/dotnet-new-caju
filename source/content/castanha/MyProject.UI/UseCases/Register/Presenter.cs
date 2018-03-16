namespace MyProject.UI.UseCases.Register
{
    using MyProject.Application;
    using MyProject.Application.UseCases.Register;
    using MyProject.UI.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class Presenter : IOutputBoundary<RegisterOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public RegisterOutput Output { get; private set; }

        public void Populate(RegisterOutput output)
        {
            Output = output;

            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }
            
            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in output.Account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            AccountDetailsModel account = new AccountDetailsModel(
                output.Account.AccountId,
                output.Account.CurrentBalance,
                transactions);

            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();
            accounts.Add(account);

            Model model = new Model(
                output.Customer.CustomerId,
                output.Customer.Personnummer,
                output.Customer.Name,
                accounts
            );

            ViewModel = new CreatedAtRouteResult("GetCustomer", new { customerId = model.CustomerId }, model);
        }
    }
}
