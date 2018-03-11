namespace Clean_FullProject.UI.UseCases.GetAccountDetails
{
    using Clean_FullProject.Application;
    using Clean_FullProject.Application.UseCases.GetAccountDetails;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<GetAccountDetailsInput> getAccountDetailsInput;
        private readonly Presenter getAccountDetailsPresenter;

        public AccountsController(
            IInputBoundary<GetAccountDetailsInput> getAccountDetailsInput,
            Presenter getAccountDetailsPresenter)
        {
            this.getAccountDetailsInput = getAccountDetailsInput;
            this.getAccountDetailsPresenter = getAccountDetailsPresenter;
        }

        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            var request = new GetAccountDetailsInput(accountId);

            await getAccountDetailsInput.Process(request);
            return getAccountDetailsPresenter.ViewModel;
        }
    }
}
