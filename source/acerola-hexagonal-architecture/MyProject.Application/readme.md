## CQRS

To make easier to understand the different protocols that Application Layer support, I segregated it in two stacks that ends in two different Models.

![Hexagonal Architecture](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/cqrs.png)

To correctly implement CQRS we need to implement our methods following the ideas of CQS, methods that changes state should not have an return value. Methods that return an value should not change state. Then the CQRS is following different paths on the system one for the Read Model and other for the Write Model.

1. One stack for the Commands that makes changes to the application state. They are enforced by the Domain Layer, processed by the Application Services which calls the Repositories for persistence.
2. The other is a tinner stack for the Queries that calls the repositories directly.

### Commands

To see how it is implemented with .NET, take a look at the following Application Service for the Deposit Use Case:

```
public class DepositService : IDepositService
{
  private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
  private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
  private readonly IResultConverter resultConverter;

  public DepositService(
    IAccountReadOnlyRepository accountReadOnlyRepository,
    IAccountWriteOnlyRepository accountWriteOnlyRepository,
    IResultConverter resultConverter)
  {
    this.accountReadOnlyRepository = accountReadOnlyRepository;
    this.accountWriteOnlyRepository = accountWriteOnlyRepository;
    this.resultConverter = resultConverter;
  }

  public async Task Process(DepositCommand command)
  {
    Account account = await accountReadOnlyRepository.Get(command.AccountId);
    if (account == null)
      throw new AccountNotFoundException(
      $"The account {command.AccountId} does not exists or is already closed.");

    Credit credit = new Credit(account.Id, command.Amount);
    account.Deposit(credit);

    await accountWriteOnlyRepository.Update(account, credit);

    TransactionResult transactionResult = resultConverter.Map(credit);
    DepositResult result = new DepositResult(
      transactionResult,
      account.GetCurrentBalance().Value);

    return result;
  }
}
```

### Queries

And for the Query side, see that we only have an method signature delegating the implementation details to an Repository Adapter. By having an guarantee that the method does not do anything you can take advantage of better solutions for writing and reading operations. For instance we can use caching for reading, segregated databases to boost performance or transaction scopes for the Commands.

```
public interface IAccountsQueries
{
  Task<AccountResult> GetAccount(Guid id);
}
```

### Use Cases Components

It is very important to organize the Application Layer in a meaningful way, one good option is to organize the Commands and Queries by Use Cases, so we have folders with:

* Command (DepositCommand)
* Application Service Interface (IDepositService)
* Application Service Implementation (DepositService)
* Command Result (DepositResult)

With this approach we have an application design that supports new use case implementations with few changes in existing code base. This keep the work effort for new use cases implementations constants along the sprints in an Agile methodology.

### How to Prevent Business Degradation

Sharing my experience with designing Application Layers, I can tell that Visual Studio facilitates adding libraries like Reflection, Serialization, Http, Bus or frameworks in our use cases. Which remove value from the business. I agree with Robert Martin when he defines Business Rules:

> Business Rules would make or save the business money, irrespective of whether they were implemented on a computer. They would make or save money even if they were executed manually.

And I add that everything else is just details, probably they are well served as Adapters.
