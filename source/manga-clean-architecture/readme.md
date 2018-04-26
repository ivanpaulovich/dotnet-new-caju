# Clean Architecture for .NET Applications – Paulovich.NET

I'd like to introduce my service template for .NET Applications based on the Clean Architecture style. You can download the full [Source Code](https://github.com/ivanpaulovich/manga-clean-architecture "Permalink to Manga Clean Architecture")
 or you can play with the `dotnet new caju` tool using the following commands:
    
    
    $ dotnet new -i Paulovich.Caju::0.4.2
    $ dotnet new clean \
      --data-access mongo \
      --use-cases full \
      --user-interface webapi

Clean Architecture [expects at least 4 layers](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html "The Clean Architecture") and in each layer there are common components. Starting with the layers from inside to the outer ones:

![Clean Architecture Diagram by Uncle Bob](https://paulovich.net/wp-content/uploads/2018/04/CleanArchitecture-Uncle-Bob.jpg)

*Clean Architecture Diagram by Uncle Bob*

1. Enterprise Business Rules
2. Application Business Rules
3. Interface Adapters
4. Frameworks & Drivers
