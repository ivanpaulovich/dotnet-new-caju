## Ports
An Port is an way an Actor can interact with the Application Layer. The role of the Port is to translate the Actor’s input into structures the Application Services can understand. For instance an Port could be an Web Application, an Console App or a Batch Script. I need to point out that the Actor could be an real user or another system.

For this article the Port supports the REST protocol and was implemented using WebApi framework.

```
[Route("api/[controller]")]
public class AccountsController : Controller
{
  private readonly IDepositService depositService;

  public AccountsController(
    IDepositService depositService)
  {
    this.depositService = depositService;
  }

  /// <summary>
  /// Deposit from an account
  /// </summary>
  [HttpPatch("Deposit")]
  public async Task<IActionResult> Deposit([FromBody]DepositRequest request)
  {
    var command = new DepositCommand(
      request.AccountId,
      request.Amount);

    DepositResult depositResult = await depositService.Process(command);

    if (depositResult == null)
    {
      return new NoContentResult();
    }

    Model model = new Model(
      depositResult.Transaction.Amount,
      depositResult.Transaction.Description,
      depositResult.Transaction.TransactionDate,
      depositResult.UpdatedBalance
    );

    return new ObjectResult(model);
  }
}
```

The WebApi has Controllers that dot not depends on Application Services implementation details, its easy to mock this services. In an Enterprise Application we use to have multiple Ports.

## Port Components
For the same reason we have components in Application Layer we also design components in a Port. For instance, our WebApi is organized by use cases:

* Request (DepositRequest)
* Controller + Action (DepositController)
* Model
