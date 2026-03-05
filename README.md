# Clean Architecture .NET API with JWT Authentication
Client Management System

This project is a REST API built with ASP.NET Core 10 following Clean Architecture principles.

It demonstrates:
- JWT authentication
- Multi-user client isolation
- Clean service and repository layers
- Entity Framework Core with SQL Server
- Swagger documentation for testing endpoints

## Technologies
- ASP.NET Core 10
- Clean Architecture
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger / OpenAPI
- Dependency Injection

## Architecture
- Controllers: receive HTTP requests and validate JWT tokens
- Services: business logic layer
- Repositories: access to the database
- DbContext: EF Core configuration and SQL Server access
- DTOs: models used for input and output
- Migrations: database schema updates managed by EF Core

## Multi-user Isolation
- Each user receives a JWT containing their UserId
- The Clients table contains a property called OwnerUserId
- Endpoints protected with [Authorize] read the authenticated user
- Each user can only access clients where OwnerUserId matches their UserId

## How to Run the Project
1. Clone the repository
2. Update the SQL Server connection string in `appsettings.json`
3. Execute the migrations
4. Run the project

## Endpoints
### Auth
- POST /api/auth/register
- POST /api/auth/login → returns JWT

### Clients
Protected with [Authorize]
- GET /api/clients
- POST /api/clients
- GET /api/clients/{id}

## How to Test with Swagger
1. Run the project
2. Use POST /api/auth/login
3. Copy the JWT token
4. Click the Authorize button and paste the token
5. Try the protected endpoints

## Features
- JWT authentication
- Clean Architecture structure
- Multi-user client isolation
- Full CRUD operations for clients
- Swagger documentation
- EF Core with SQL Server

## LICENSE
MIT License

Copyright (c) 2026 Lina Perez

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software...
