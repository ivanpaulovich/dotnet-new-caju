namespace MyFullProject.UI.UseCases.Deposit
{
    using MyFullProject.Application;
    using MyFullProject.Application.UseCases.Deposit;
    using Microsoft.AspNetCore.Mvc;

    public class Presenter : IOutputBoundary<DepositOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public DepositOutput Output { get; private set; }

        public void Populate(DepositOutput response)
        {
            Output = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new Model(
                response.Transaction.Amount,
                response.Transaction.Description,
                response.Transaction.TransactionDate,
                response.UpdatedBalance
            ));
        }
    }
}
