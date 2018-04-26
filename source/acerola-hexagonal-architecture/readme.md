## Architecture Style Characteristics

With this style we have an independent Domain to embody small set of critical business rules. Ports giving access to the Application Services, Adapters that provides interfaces to frameworks, databases and other systems. One way to explain the Hexagonal Architecture is by its shapes. Take a look at the following picture:

![Hexagonal Architecture](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/hexagonal.png)

* At the center we have the Domain with a small potato shape and there is reason for it. Every business domain has its own rules, different specifications from each other, that is the reason of this undefined shape. For instance in our very specific example we designed it with DDD Patterns.
* The business rules known as the Domain and the Application does not know the Adapters implementations.
* The application has an hexagonal shape because each of its sides has specifics protocols, in our example we have **Commands** and **Queries** giving access to the Application Services.
* The Ports and Adapters are implemented outside of the application as plugins.
* Externally we have other systems.
* The application components are loose coupling making changes faster.

For all the benefits Hexagonal Architectural brings in the box we start thinking that design it is hard, but as we gain experience with Dependency Inversion Principle and Separation of Concerns then the implementation become natural. The second thought is "Is it proven a good solution?" and I have to point out that articles from [Alistair Cockburn](http://alistair.cockburn.us/Hexagonal+architecture) is 13 years and recently [Building Microservices](https://samnewman.io/talks/principles-of-microservices/) bring confidence.

## Layers

The software use layers for Separation of Concerns and to enforce the application design. The consequences of this choices are well described by [Vaughn Vernon (IDDD, 2013)](https://www.amazon.com/Implementing-Domain-Driven-Design-Vaughn-Vernon/dp/0321834577):

> The essence of this definition is communicating that a component that provides low-level services (Infrastructure, for this discussion) should depend on interfaces defined by high-level components (for this discussion, User Interface, Application, and Domain)

Let's describe the Dependency Layer Diagram below:

![Layered Application](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/Layers.png)

* The domain is totally independent of other layers and frameworks.
* The application depends on Domain and is independent of frameworks, databases and UI.
* Adapters provides implementations for the Application needs.
* The UI depends on Application and loads the Infrastructure by indirection.

We should pay attention that Infrastructure usually has different dependencies and could be separated projects for database, bus, security, DI frameworks and other peripheral concerns. For didactic reasons we present only one project for Infrastructure.
