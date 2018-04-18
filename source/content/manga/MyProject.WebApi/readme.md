## 3\. Interface Adapters

Now we advance to the next layer, at the Interface Adapters Layer we translate the User input in a way that the Interactors understands, it is good practice to do not reuse entities in this layer because it creates coupling, the front-end has frameworks, other ways of creating his data structures, different presentation for each field and validation rules.

In our implementation we have the following components for every use case:

* **Request**: a data structure for the user input.
* **A Controller with an Action**: this component receives the user input, calls the appropriate Interactor which do some processing then pass the output through the Presenter instance.
* **Presenter**: it converters the Output to the Model.
* **Model**: this is the return data structure for MVC applications.

And this is how looks a Controller for the Register Use Case. We must highlight that the Controller knows which Interactor to call but it does not care about the Output of it, instead the Controller delegates the responsibility of generating a Model to the Presenter instance.
    
    
    [Route("api/[controller]")]
    public class CustomersController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary registerInput;
        private readonly Presenter registerPresenter;
    
        public CustomersController(
            IInputBoundary registerInput,
            Presenter registerPresenter)
        {
            this.registerInput = registerInput;
            this.registerPresenter = registerPresenter;
        }
    
        ///
        /// Register a new Customer
        /// 

        [HttpPost]
        public async Task Post([FromBody]RegisterRequest message)
        {
            var request = new RegisterInput(
               message.PIN, message.Name, message.InitialAmount);
            await registerInput.Process(request);
            return registerPresenter.ViewModel;
        }
    }

An Presenter class is detailed bellow and it shows a conversion from the RegisterOutput to two different ViewModels. One ViewModel for null Outputs and another ViewModel for successful registrations.
    
    
    public class Presenter : IOutputBoundary
    {
        public IActionResult ViewModel { get; private set; }
        public RegisterOutput Output { get; private set; }
    
        public void Populate(RegisterOutput response)
        {
            Output = response;
    
            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }
            
            List transactions = new List();
    
            foreach (var item in response.Account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);
    
                transactions.Add(transaction);
            }
    
            AccountDetailsModel account = new AccountDetailsModel(
                response.Account.AccountId,
                response.Account.CurrentBalance,
                transactions);
    
            List accounts = new List();
            accounts.Add(account);
    
            Model model = new Model(
                response.Customer.CustomerId,
                response.Customer.Personnummer,
                response.Customer.Name,
                accounts
            );
    
            ViewModel = new CreatedAtRouteResult("GetCustomer", 
                new { customerId = model.CustomerId }, 
                model);
        }
    }
