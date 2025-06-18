
# Tech Racing F1 API 🏎️

<p align="center">
  <img src="src/TechRacingF1.WebApi/Assets/Images/bg-min.jpeg" alt="Logo" >
</p>

  <p align="center">Technologies used.</p>
    <p align="center">
<a href="https://dotnet.microsoft.com/en-us/" target="_blank"><img src="https://img.shields.io/badge/.NET-8.0-blueviolet" alt=".NET 8.0"></a>
<a href="https://learn.microsoft.com/en-us/aspnet/core/" target="_blank"><img src="https://img.shields.io/badge/ASP.NET%20Core-8.0-blue" alt="ASP.NET Core 8.0"></a>
<a href="https://docs.microsoft.com/en-us/ef/core/" target="_blank"><img src="https://img.shields.io/badge/Entity%20Framework%20Core-9.0.5-green" alt="Entity Framework Core 9.0.5"></a>
<a href="https://github.com/jbogard/MediatR" target="_blank"><img src="https://img.shields.io/badge/MediatR-12.5.0-ff69b4" alt="MediatR 12.5.0"></a>
<a href="https://fluentvalidation.net/" target="_blank"><img src="https://img.shields.io/badge/FluentValidation-12.0.0-brightgreen" alt="FluentValidation 12.0.0"></a>
<a href="https://automapper.org/" target="_blank"><img src="https://img.shields.io/badge/AutoMapper-14.0.0-orange" alt="AutoMapper 14.0.0"></a>
<a href="https://serilog.net/" target="_blank"><img src="https://img.shields.io/badge/Serilog-4.3.0-lightgrey" alt="Serilog 4.3.0"></a>
<a href="https://swagger.io/" target="_blank"><img src="https://img.shields.io/badge/Swagger%20%2F%20OpenAPI-8.1.3-yellowgreen" alt="Swagger/OpenAPI 8.1.3"></a>
<a href="https://www.microsoft.com/sql-server" target="_blank"><img src="https://img.shields.io/badge/SQL%20Server-2022-red" alt="SQL Server"></a>
</p>

## Description📍

Services for simulating and managing F1 racing data.
This project implements a layered architecture following the principles of Clean Architecture and Domain-Driven Design (DDD).

### Algorithm 🧠

The main algorithm, responsible for generating strategies based on a defined number of laps, uses a recursive approach to explore all possible combinations of tire types and stint lengths for a given number of stops, ensuring that lap restrictions and a minimum number of laps per stint are met, and then ranks the resulting strategies based on efficiency criteria.

The algorithm uses a dynamic programming approach to efficiently explore the search space, minimizing the number of combinations considered.

## Project Structure 🗂️

```
Solution 'TechRacingF1'
├── src/
│   ├── TechRacingF1.WebApi                 # Presentation Layer - REST API
│   ├── TechRacingF1.Application         # Application Layer - Use Cases
│   ├── TechRacingF1.Domain              # Domain Layer - Entities and Business Rules
│   └── TechRacingF1.Infrastructure      # Infrastructure Layer - Concrete Implementations
```

## Application Layers 🧩

### Domain Layer (TechRacingF1.Domain) 🏛️
Contains business entities, repository interfaces, domain events, and business rules. This layer is independent of any external framework or technology.

### Application Layer (TechRacingF1.Application) ⚙️
Contains application logic and orchestration. Implements use cases that coordinate the flow of data to and from domain entities, and directs those entities to use their business rules to achieve the objectives of the use case.

### Infrastructure Layer (TechRacingF1.Infrastructure) 🏗️
Contains concrete implementations of interfaces defined in the domain and application layers. Includes data access, external services, logging, etc.

### Presentation Layer (TechRacingF1.WebApi) 🌐
Exposes the application's functionality through a REST API. Handles HTTP requests, input validation, and response serialization.

## Implemented Patterns 🧩

- **Repository Pattern**: To abstract data access
- **Mediator Pattern (CQRS)**: To separate read and write operations
- **Unit of Work**: To manage transactions
- **Dependency Injection**: To decouple components
- **Options Pattern**: To manage configuration
- **Specification Pattern**: For complex queries
- **Validation Pattern**: For data validation
- **Logging**: To track application events and errors
- **Error Handling**: To provide meaningful error messages

## Database Schema 📚

Below is our database schema diagram showing the relationships between tables:

<p align="center">
  <img src="src/TechRacingF1.WebApi/Assets/Images/er-TechRacingF1-min.png" alt="Database Schema" width="700"/>
</p>

## SQL Scripts 💡

You can find the database initialization and setup scripts in the `database/schema-sqlserver.sql` file. This script contains:

- Database creation
- Table creation statements with indexes and constraints
- Initial data seeding

To set up your database, execute the SQL Server script in the following order:
1. Ensure you have appropriate permissions on your SQL Server instance
2. Execute the complete script using SQL Server Management Studio or your preferred SQL tool
3. Verify the database and its objects are created successfully

## Installation 📦

To install and run the project, follow these steps:

1. Clone the repository
```bash
git clone https://github.com/desobsesor/tech-racing-f1-api.git
```
2. Run the maven command
```bash
dotnet restore
```
3. Run the application
```bash
dotnet run --project src/TechRacingF1.WebApi/TechRacingF1.WebApi.csproj
```

## Built with 🛠️

_Tools and Technologies used_

- [.NET 8](https://dotnet.microsoft.com/en-us/) - Development platform for modern, high-performance applications
- [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/) - Framework for building RESTful APIs and web applications
- [Entity Framework Core 9.0.5](https://docs.microsoft.com/en-us/ef/core/) - Modern ORM for SQL Server database access
- [MediatR 12.5.0](https://github.com/jbogard/MediatR) - Mediator pattern implementation for CQRS
- [FluentValidation 12.0.0](https://fluentvalidation.net/) - Model and business rules validation
- [AutoMapper 14.0.0](https://automapper.org/) - Object-to-object mapping
- [Serilog 4.3.0](https://serilog.net/) - Structured logging
- [Swagger/OpenAPI 8.1.3](https://swagger.io/) - Interactive API documentation

## Documentation 📖

http://localhost:5225/swagger/index.html

## Security 🔒

This API uses `X-API-Key` for basic authentication. To access protected endpoints, you must include a valid `X-API-Key` in your request headers. For use in

Example:

```
X-API-Key: API_KEY
```

## Author ✒️

_Built by_

- **Yovany Suárez Silva** - _Full Stack Software Engineer_ - [desobsesor](https://github.com/desobsesor)
- Website - [https://portfolio.cds.net.co](https://desobsesor.github.io/portfolio-web/)

## License 📄

This project is under the MIT License - see the file [LICENSE.md](LICENSE.md) for details


