Caju: Back-end with awesome architectures made easy!
=========
Service Template to help you build evolvable and maintainable applications. Its was built following SOLID principles and on Domain-Driven Design. This tool increases productivity on developing your next microservices.

## Generate your own awesome Back-end!

```sh
dotnet new -i Paulovich.Caju::0.3.3
dotnet new caju
```

## The Architecture Styles

We prevent our software to be coupled from technology details like User Interface, Data Access frameworks or Web Servers. And there are some concepts that guided us:

* Allow an application to equally be driven by users, programs, automated test or batch scripts, and to be developed and tested in isolation from its eventual run-time devices and databases.
* The SOLID principles are all over the the solution.
* The software implementation is agnostic from technology, framework, or database. The result is focus on the  use cases with input/output ports. |
* Designed around the Business Domain, having Continous Delivery and Independent Deployment.

## Sample applications

Run `dotnet new -i Paulovich.Caju` then try the following commands.

Clean Architecture Solution with basic use cases:

```sh
dotnet new caju \
  --architecture-style clean \
  --use-cases basic
```

Hexagonal Architecture Solution with all use cases:

```sh
dotnet new caju \
  --architecture-style hexagonal \
  --use-cases full
```

Empty Event-Sourcing Solution:

```sh
dotnet new caju \
  --architecture-style eventsourcing \
  --use-cases empty
```

For olher solution types check out the [Caju Samples folder](https://github.com/ivanpaulovich/caju/tree/master/samples).

## Switches

There are switches to generate your awesome application with your needs. Try after `dotnet new caju`:

| Switch | Default Value | Options |
| --- | --- | --- |
| --architecture-style | `clean` | `clean` `hexagonal` `eventsourcing` |
| --use-cases | `full` | `full` `basic` `readonly` `none` |
| --user-interface | `webapi` | `webapi` `consoleapp` `wcf` `none` |
| --data-access | `mongo` | `mongo` `entityframework` `dapper` `none` |
| --service-bus | `kafka` | `kafka` `none` |
| --tips | `true` | `true` `false` |
| --skip-restore | `false` | `true` `false` |

Run `dotnet new caju --help` for the complete list of switches.

## Common Issues

Check your [.NET Core SDK](https://www.microsoft.com/net/download/windows). Our features are only supported in `2.1.4` SDK or plus.

```sh
$ dotnet --version
2.1.4
```
