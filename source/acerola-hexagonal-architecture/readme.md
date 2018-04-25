## Architecture Style Characteristics

With this style we have an independent Domain. Ports giving access to the Application Services, Adapters that provides interfaces to frameworks, databases and other systems. One way to explain the Hexagonal Architecture is by its shapes. Take a look:

![Hexagonal Architecture](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/hexagonal.png)

* At the center we have the Domain with a potato shape and there is reason for it. Every business domain has its own rules, different specifications from each other, that is the reason of this undefined shape. For instance in our very specific example we designed it with DDD Patterns.
* The business rules known as the Domain and the Application does not know the Adapters implementations.
* The application has an hexagonal shape because each of its sides has specifics protocols, in our example we have Commands and Queries giving access to the Application Services.
* The Ports and Adapters are implemented outside of the application as plugins.
* Externally we have other systems.

## Application Layers

The software use layers to segregate responsibilities and to enforce design. The consequences of this choices are:

![Layered Application](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/Layers.png)

* The domain is totally independent of other layers and frameworks.
* The application depends on Domain and is independent of frameworks, databases and UI.
* Adapters provides implementations for the Application needs.
* The software can evolve faster.
* When the UI is the Host it loads the Infrastructure by indirection.
