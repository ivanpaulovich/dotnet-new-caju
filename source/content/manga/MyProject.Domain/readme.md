## **1\. Enterprise Business Rules**

Beginning with the Enterprise Business Rules Layer we are talking about Aggregates, Entities, Value Objects and others patterns of a rich Domain. In our specific Bounded Context we have the Customer and the Account as **Aggregate Roots**, also the Credit/Debit transactions as **Entities** and last but no least we have the Name, Person Number and Amount as **Value Objects**.

![Account Balance Context](https://paulovich.net/wp-content/uploads/2018/04/Account-Balance-Context.png)

In short words, the previous components are the business entities that encapsulates fields and prevents unexpected changes or behaviors, these components maintain the application state in the most reliable way. Now, let me highlight some characteristics of this data structures:

* Aggregate Roots controls the entities graph and are used by repositories for data persistence. The software craftsman Vaugn Vernon wrote the [rules for designing effective aggregates](https://vaughnvernon.co/?p=838) and I highly recommend watching the video [Curing you Domain Model Anemia with Effective & Clean Tips from the Real World](https://www.youtube.com/watch?v=zzxinXTIMmo) from Edson Yanaga these helped me a lot to enrich my model.
* You will see that majority of the classes have properties with _private sets_ or _protected sets_ in order to prevent unexpected state changes from the several clients along the Use Cases (we avoid _public sets when possible)_.
* We had to make exceptions for _constructors_ due of deserialization requirements.
* Value Objects are expected to be immutable and they have the most closed fields. Fields that change only when we create a new instance of the Value Object.

You can find interesting Domain Entities in our GitHub, following there are an Aggregate Root example:
    
    
    public class Customer : Entity, IAggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual PIN PIN { get; protected set; }
        public virtual int Version { get; protected set; }
        public virtual AccountCollection Accounts { get; protected set; }
    
        protected Customer()
        {
            Accounts = new AccountCollection();
        }
    
        public Customer(PIN pin, Name name)
            : this()
        {
            PIN = pin;
            Name = name;
        }
    
        public virtual void Register(Guid accountId)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accountId);
        }
    }
