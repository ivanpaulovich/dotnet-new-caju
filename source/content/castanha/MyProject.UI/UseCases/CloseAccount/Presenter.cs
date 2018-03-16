namespace MyProject.UI.UseCases.CloseAccount
{
    using MyProject.Application;
    using MyProject.Application.UseCases.CloseAccount;
    using Microsoft.AspNetCore.Mvc;
    public class Presenter : IOutputBoundary<CloseOutput>
git
    {
        public IActionResult ViewModel { get; private set; }
        public CloseOutput Output { get; private set; }

        public void Populate(CloseOutput output)
        {
            Output = output;

            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new OkResult();
        }
    }
}