## **2\. Application Business Rules**

Let's move to the Application Business Rules Layer that contains the Use Cases of our Bounded Context. As said by Uncle Bob in his book Clean Architecture:

> Just as the plans for a house or a library scream about the use cases of those buildings, so should the architecture of a software application scream about the use cases of the application.

So our Use Cases implementations are first-class modules in the root of this layer. The shape of a Use Case is an **Interactor** object that receives an **Input**, do some work then pass the **Output** through the currently **Presenter** instance as shown in the following figure:

![Clean Architecture Diagram by Uncle Bob](https://paulovich.net/wp-content/uploads/2018/04/Flow-Of-Control.png)

In the previous Flow of Control we have:

1. An **Action** in the **CustomersController** calls a method in the **RegisterInteractor** with the **RegisterInput** data;
2. The **RegisterInteractor** that implements **IInputBoundary** calls the **CustomerRepository** passing the **CustomerAggregate** object created in that Use Case.
3. Then the **RegisterInteractor** generates a RegisterOutput data object (POCO) and passes it to the currently IOutputBoundary.
4. The **RegisterPresenter** which implements **IOutputBoundary** receives the **RegisterOutput** and creates the **RegisterModel**.
5. The **RegisterModel** created in step 4 are returned by the **Action**.

In our example application we have other Use Cases that allow Customer Registration and Bank Account transactions. In simple terms these are the Use Cases:

* Customer Registration.
* Get Customer Account Details.
* Get Account Details.
* Deposit to an account.
* Withdraw from an account.
* Close an account.

Continuing to explore our implementation you will see that the **RegisterInteractor** receives the services by DI. The Process method does the Application Business Rules, calls the Repository and at the end passes the **RegisterOutput** through the **RegisterPresenter** instance. Let's take a look at the RegisterInteractor class:
    
    
    public class RegisterInteractor : IInputBoundary
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary outputBoundary;
        private readonly IOutputConverter outputConverter;
        
        public RegisterInteractor(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary outputBoundary,
            IOutputConverter outputConverter)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.outputConverter = outputConverter;
        }
    
        public async Task Process(RegisterInput input)
        {
            Customer customer = new Customer(input.PIN, input.Name);
    
            Account account = new Account(customer.Id);
            Credit credit = new Credit(account.Id, input.InitialAmount);
            account.Deposit(credit);
    
            customer.Register(account.Id);
    
            await customerWriteOnlyRepository.Add(customer);
            await accountWriteOnlyRepository.Add(account, credit);
    
            CustomerOutput customerOutput = outputConverter.Map(customer);
            AccountOutput accountOutput = outputConverter.Map(account);
            RegisterOutput output = new RegisterOutput(customerOutput, accountOutput);
    
            outputBoundary.Populate(output);
        }
    }

What have you seen until here is **Enterprise + Application Business Rules** enforced without frameworks dependencies or without database coupling. Every details have abstractions protecting the Business Domain to be coupled to tech stuff.
