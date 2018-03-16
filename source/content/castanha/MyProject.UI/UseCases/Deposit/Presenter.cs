namespace MyProject.UI.UseCases.Deposit
{
    using MyProject.Application;
    using MyProject.Application.UseCases.Deposit;
    using Microsoft.AspNetCore.Mvc;

    public class Presenter : IOutputBoundary<DepositOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public DepositOutput Output { get; private set; }

        public void Populate(DepositOutput output)
        {
            Output = output;

            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new Model(
                output.Transaction.Amount,
                output.Transaction.Description,
                output.Transaction.TransactionDate,
                output.UpdatedBalance
            ));
        }
    }
}
