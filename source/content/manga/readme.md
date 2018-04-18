[Source](https://paulovich.net/clean-architecture-for-net-applications/ "Permalink to Clean Architecture for .NET Applications – Paulovich.NET")

# Clean Architecture for .NET Applications – Paulovich.NET

I'd like to introduce my service template for .NET Applications based on the Clean Architecture style. You can download the full [source code][1] or you can play with the [dotnet new caju ][2]tool using the following commands:
    
    
    $ dotnet new -i Paulovich.Caju::0.3.1
    $ dotnet new caju --architecture-style clean 
      --data-access mongo 
      --use-cases full 
      --user-interface webapi

As the SOLID principles and the Clean Architecture rules are worth to write about it, I am starting this blogging series explaining the decisions we have made through the development of the Manga Project. Feedback are welcome!

Clean Architecture [expects at least 4 layers][3] and in each layer there are common components. Starting with the layers from inside to the outer ones:

![Clean Architecture Diagram by Uncle Bob][4]

Clean Architecture Diagram by Uncle Bob

1. Enterprise Business Rules
2. Application Business Rules
3. Interface Adapters
4. Frameworks & Drivers