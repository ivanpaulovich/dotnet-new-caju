## Adapters

Adapters provides implementations for the peripheral concerns, you can have an Repository Adapter for your SQL Database, an Adapter for that legacy WCF Service or even an Adapter for that NewtonSoft.Json framework. What we need to pay attention on designing adapters for long term?

* Adapters should implement the Application needs, not the opposite!
* An adapter interface does not expose internal implementation signatures and data structures.

Our specific Infrastructure is a single project that implements data access, mappings and DI framework. In a convenient moment I can split this project in Infrastructure.MongoDataAccess, Infrastructure.Mappings and so on.

## The Plugin Argument

At this time we have seen a lot of components and that was the intention, the Hexagonal Architecture Style is very flexible because it is very adaptable by external implementations as plugins. And this is well exemplified by the Plugin Argument coined by Robert Martin, he said about the relationship between Visual Studio and Resharper. You that the development is completely isolated, the Microsoft teams does not know the details about Resharper and yet they run very well together.

## Components Overview

You noticed that I use specific organization patterns for grouping the modules by use cases, I recommend that as I can evolve the application along the sprints with less changes in the existing code base.
