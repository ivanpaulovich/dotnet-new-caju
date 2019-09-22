![Caju](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/caju-icon.png) Caju: .NET apps with awesome architectures!
=========
Service Template to help you build evolvable and maintainable applications. It follows the Clean Architecture Principles and built on Domain-Driven Design. This tool increases productivity on developing your next microservices.

## Generate your own awesome Back-end!
<a href="https://www.nuget.org/packages/Paulovich.Caju/" rel="Paulovich.Caju">![NuGet](https://buildstats.info/nuget/paulovich.caju)</a> [![Build Status](https://travis-ci.org/ivanpaulovich/dotnet-new-caju.svg?branch=master)](https://travis-ci.org/ivanpaulovich/dotnet-new-caju) [![Gitter](https://img.shields.io/badge/chat-on%20gitter-blue.svg)](https://gitter.im/ivanpaulovich/)

To generate your own awesome .NET Back-end simple run:

```sh
dotnet new -i Paulovich.Caju::0.7.2
dotnet new manga
```

## Clean Architecture

Based on [Clean Architecture Manga](https://github.com/ivanpaulovich/clean-architecture-manga).

## Sample applications

Run `dotnet new -i Paulovich.Caju` then try the following commands.

Complete suite of use cases.

```sh
dotnet new clean --use-cases full
```

Register account and get customer details.

```sh
dotnet new clean --use-cases basic
```

Read only use cases

```sh
dotnet new clean --use-cases readonly
```