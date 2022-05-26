 
# Inventory Manager

This is a solution that simulates an inventory manager application.



## Technologies

* [ASP.NET Core 5](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)



## Getting Started

There are two options to run the app:
1. Directly in .Net Core CLI:
1.1. Check if .NET Core 5 is already installed; if not, install it from (https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
1.2. Open a cmd in `...\InventoryManager\src\API`
1.3. Run the command `dotnet run`
1.4. Open a browser and visit `https://localhost:5001/swagger/index.html`

2. From Visual Studio IDE:
1.1. Check if .NET Core 5 is already installed; if not, install it from (https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
1.2. Open the solution in VS
1.3. Select the API project as startup project
1.4. Run the app with IIS Express selected



## Overview

### Domain

This contains all business logic like domain entities, enums, domain events objects and some cross-cutting interfaces to be used in anywhere part of the app. 

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This project contains all the commands and queries (definition, validation and handler), the domain event handlers, background services, etc.

### Infrastructure

This layer implements the data persistence and the logging implementation. It only depends on application layer.

### API

This layer is an ASP.NET Core 5 WebAPI. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection.



## Design Patterns

### DDD (Domain-driven design)
Domain-driven design (DDD) is a software design approach focusing on modelling software to match a domain according to input from that domain's experts.

### CQRS
Command query responsibility segregation (CQRS) is a programming design pattern that treats retrieving data and changing data differently. CQRS uses command handlers to simplify the query process and hide complex, multi-system changes.

### Mediator Patterns
Mediator pattern is used to reduce dependencies between objects. It allows in-process messaging, but it will not allow direct communication between objects.



## Third Party Nuget Packages

### Microsoft.EntityFrameworkCore.InMemory
I have used this nuget because it is an easy and fast way to implement a database in memory. Also, EF Core is the main Micro ORM used in .Net environment.

### Microsoft.Extensions.Logging
This nuget has been selected because it is a versatile way to implement a logging system and the owner is microsoft.

### AutoMapper
I have used AutoMapper because it is a library used to map data from one object to another. It acts as a mapper between two objects and transforms one object type into another what is a very common and repetitive task in this kind of apps (to map from domain models to DTOs). This is the nuget that I have saw in all the projects where I have worked.

### FluentValidation
FluentValidation is one way of setting up dedicated validator objects, that you would use when you want to treat validation logic as separate from business logic. This is the library used for Microsoft in their examples of clen architecture.

### MediatR
This library is the reference in all tutorials you can find in internet about DDD, CQRS, etc. including Microsoft examples because it is a very easy and powerful library to implement a messaging service in memory.


