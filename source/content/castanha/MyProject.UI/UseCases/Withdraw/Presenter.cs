namespace MyProject.UI.UseCases.Withdraw
{
    using MyProject.Application;
    using MyProject.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public class Presenter : IOutputBoundary<WithdrawOutput>
    {
        public IActionResult ViewModel { get; private set; }

        public WithdrawOutput Output { get; private set; }

        public void Populate(WithdrawOutput output)
        {
            Output = output;

            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new
            {
                Amount = output.Transaction.Amount,
                Description = output.Transaction.Description,
                TransactionDate = output.Transaction.TransactionDate,
                UpdateBalance = output.UpdatedBalance,
            });
        }
    }
}
