namespace Full_Solution.UI.UseCases.Withdraw
{
    using Full_Solution.Application;
    using Full_Solution.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<WithdrawInput> withdrawInput;
        private readonly Presenter withdrawPresenter;
        
        public AccountsController(
            IInputBoundary<WithdrawInput> withdrawInput,
            Presenter withdrawPresenter)
        {
            this.withdrawInput = withdrawInput;
            this.withdrawPresenter = withdrawPresenter;
        }

        /// <summary>
        /// Withdraw from an account
        /// </summary>
        [HttpPatch("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody]WithdrawRequest message)
        {
            var request = new WithdrawInput(message.AccountId, message.Amount);

            await withdrawInput.Process(request);
            return withdrawPresenter.ViewModel;
        }
    }
}
