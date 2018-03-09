namespace Full_Solution.UI.UseCases.CloseAccount
{
    using Full_Solution.Application;
    using Full_Solution.Application.UseCases.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    public class Presenter : IOutputBoundary<CloseOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public CloseOutput Output { get; private set; }

        public void Populate(CloseOutput response)
        {
            Output = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new OkResult();
        }
    }
}