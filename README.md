# BlogPostApp

A .NET 8 layered application for a Twitter-like blog post service.

## Overview

This repository contains a multi-project solution with a layered architecture:

- `BlogPost.API` - ASP.NET Core Web API entrypoint with controllers, Swagger, and EF Core SQL Server configuration.
- `BlogPost.Business` - Business layer project for service/business logic.
- `BlogPost.DataAccess` - Data access layer with Entity Framework Core and repository implementations.
- `BlogPost.Contracts` - Shared contract models and DTOs used by the other layers.
- `BlogPost.SharedLibrary` - Shared utilities, extensions, or common components.

The application is designed so that future `BlogPost` features can be implemented similarly to a Twitter-style feed: posts, categories, and user-facing interactions.

## Architecture

This solution follows a clean layered architecture pattern:

- Controller layer in `BlogPost.API` handles HTTP requests and responses.
- Business layer in `BlogPost.Business` contains application rules and orchestrates operations.
- Data access layer in `BlogPost.DataAccess` communicates with the database using repositories.
- Contracts in `BlogPost.Contracts` define domain models and shared DTOs.
- Shared library in `BlogPost.SharedLibrary` contains reusable helpers and cross-cutting concerns.

## Key technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / Swashbuckle
- Serilog

## Running the solution

1. Open `BlogPost.API.sln` in Visual Studio or your preferred IDE.
2. Ensure the connection string in `BlogPost.API/appsettings.json` or `appsettings.Development.json` is set for your SQL Server instance.
3. Run the solution.
4. Use Swagger at the API root to explore endpoints once the app is running.

## Recommended next steps

- Add `BlogPost` entity and repository methods for create/read operations.
- Implement services in `BlogPost.Business` for posting, retrieving, and filtering posts.
- Build controllers in `BlogPost.API` to expose endpoints for a Twitter-like feed.
- Add authentication if you want users to create and manage posts.

## Project structure

- `BlogPost.API/`
  - `Program.cs`
  - `Controllers/`
  - `appsettings.json`
- `BlogPost.Business/`
  - `Services/`
  - `Interfaces/`
- `BlogPost.DataAccess/`
  - `Data/`
  - `Repository/`
- `BlogPost.Contracts/`
  - `Entities/`
- `BlogPost.SharedLibrary/`

## Notes

The current API project already configures EF Core and dependency injection for repositories. `BlogPostsController` is present and ready to be expanded with endpoints for a Twitter-like `BlogPost` flow.
