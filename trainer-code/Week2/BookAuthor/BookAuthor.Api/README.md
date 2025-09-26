# BookAuthor API


A minimal ASP.NET Core API to manage Authors, Books, and Categories.  
It demonstrates many-to-many relationships, EF Core with SQL Server in Docker, and CRUD endpoints.

## Features
- Manage Authors with one-to-one AuthorProfile
- Manage Books with one-to-many to Authors
- Categories with many-to-many with Books
- RESTful endpoints with GET, POST, PUT, DELETE
- SQL Server persistence using EF Core
- Unit tests with xUnit (20%+ coverage)

## Technologies
- .NET 9 Minimal APIs
- EF Core
- SQL Server (Docker)
- Postman (API testing)
- xUnit (Unit Testing)

## How to Run
```bash
docker-compose up -d
dotnet ef database update
dotnet run --project BookAuthor.Api
