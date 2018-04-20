![Caju](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/caju-icon.png) Caju: .NET apps with awesome architectures!
=========
Service Template to help you build evolvable and maintainable applications. It follows the principles from the [Clean Architecture book](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164) and built on Domain-Driven Design. This tool increases productivity on developing your next microservices.

![dotnet new caju](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/dotnet-new-caju-0.4.0.gif)

## Generate your own awesome Back-end!
<a href="https://www.nuget.org/packages/Paulovich.Caju/" rel="Paulovich.Caju">![NuGet](https://buildstats.info/nuget/paulovich.caju)</a> [![Build Status](https://travis-ci.org/ivanpaulovich/dotnet-new-caju.svg?branch=master)](https://travis-ci.org/ivanpaulovich/dotnet-new-caju) [![Gitter](https://img.shields.io/badge/chat-on%20gitter-blue.svg)](https://gitter.im/ivanpaulovich/)

To generate your own awesome .NET Back-end simple run:

```sh
dotnet new -i Paulovich.Caju::0.4.0
dotnet new clean
```

## The Architecture Styles

We prevent our software to be coupled from technology details like User Interface, Data Access frameworks, Service Bus or Web Servers. And there are some concepts that guided us:

* Allow an application to equally be driven by users, programs, automated test or batch scripts, and to be developed and tested in isolation from its eventual run-time devices and databases.
* The SOLID principles are all over the the solution.
* The software implementation is agnostic from technology, framework, or database. The result is focus on the  use cases with input/output ports.
* Designed around the Business Domain, having Continous Delivery and Independent Deployment.

## Sample applications

Run `dotnet new -i Paulovich.Caju` then try the following commands.

Clean Architecture Solution with basic use cases:

```sh
dotnet new clean --use-cases basic
```

Hexagonal Architecture Solution with all use cases:

```sh
dotnet new hexagonal --use-cases full
```

Empty Event-Sourcing Solution:

```sh
dotnet new eventsourcing --use-cases empty
```

For olher solution types check out the [Caju Samples folder](https://github.com/ivanpaulovich/caju/tree/master/samples).

## Switches

There are switches to generate your awesome application with your needs. Try after `dotnet new clean` or `dotnet new hexagonal` or `dotnet new eventsourcing`:

* --use-cases `full` `basic` `readonly` `none`
* --user-interface `webapi` `none`
* --data-access `mongo` `entityframework` `dapper` `none`
* --service-bus `kafka` `none`
* --tips `true` `false`
* --skip-restore `true` `false`

Use the switch `--help` for the complete list of options.

## Roadmap

* Allow to choose the **architecture style**
  * [Clean Architecture](https://github.com/ivanpaulovich/manga) :white_check_mark:
  * [Hexagonal Architecture](https://github.com/ivanpaulovich/acerola) :white_check_mark:
  * [Event-Sourcing](https://github.com/ivanpaulovich/castanha) :white_check_mark:
* Allow to choose the built-in **use cases sets**
  * Full set of use cases :white_check_mark:
  * Basic set of use cases :white_check_mark:
  * Read Only :white_check_mark: 
  * None :white_check_mark:	
* Allow to choose the **data access** frameworks 
  * MongoDB :white_check_mark:
  * Dapper :white_check_mark:
  * Entity Framework Core :white_check_mark:
  * Azure Cosmos DB
  * NHibernate Core
  * None :white_check_mark:
* Allow to choose the **UI** frameworks
  * Both
  * WebAPI :white_check_mark:
  * Console 
  * None :white_check_mark:
* Allow to choose the **Service Bus** frameworks
  * Kafka :white_check_mark:
  * Azure Event Bus
  * None :white_check_mark:
* Allow to skip the **dotnet restore** after code generation :white_check_mark:
* Allow to include or to remove the **architecture tips** :white_check_mark:

## Common Issues

Check your [.NET Core SDK](https://www.microsoft.com/net/download/windows). Our features are only supported in `2.1.4` SDK or plus.

```sh
$ dotnet --version
2.1.4
```
