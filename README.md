# Repository Pattern Demo

A demo application showcasing how to implement the Repository Pattern using Entity Framework Core within a layered .NET architecture.

## Table of Contents
- [Repository Pattern Demo](#repository-pattern-demo)
  - [Table of Contents](#table-of-contents)
  - [Overview](#overview)
  - [Features](#features)
  - [Architecture](#architecture)
    - [Layer Responsibilities](#layer-responsibilities)
  - [Database Structure](#database-structure)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Setup](#setup)
  - [API Endpoints](#api-endpoints)
    - [Category](#category)
    - [Product](#product)
  - [Usage Examples](#usage-examples)
    - [Create a Category](#create-a-category)
    - [Create a Product](#create-a-product)
    - [Get All Products](#get-all-products)
  - [License](#license)

## Overview

This repository provides a sample implementation of the Repository Pattern in a .NET 9 Web API project using Entity Framework Core and PostgreSQL. The solution is organized into multiple layers to promote clean architecture principles:
- **Domain**: Entity definitions
- **Data Access**: Repository implementations and database context
- **Business**: Service layer and business logic
- **WebAPI**: RESTful API endpoints

## Features
- Clean separation of concerns with layered architecture
- Generic and specific repositories for data access
- Service layer for business logic
- RESTful API for managing products and categories
- PostgreSQL database integration via Entity Framework Core

## Architecture

```
RepositoryPatternDemo/
├── RepositoryPatternDemo.Domain/        # Entity definitions (Product, Category)
├── RepositoryPatternDemo.DataAccess/    # Repositories, DbContext, Migrations
├── RepositoryPatternDemo.Business/      # Service layer, business logic
└── RepositoryPatternDemo.WebAPI/        # API controllers, startup, configuration
```

### Layer Responsibilities
- **Domain**: Contains POCO entity classes (`Product`, `Category`).
- **DataAccess**: Implements the Repository Pattern with generic and specific repositories, manages database context and migrations.
- **Business**: Contains service interfaces and implementations for business logic, orchestrates repository usage.
- **WebAPI**: Exposes RESTful endpoints for CRUD operations on products and categories.

## Database Structure

- **Category**
  - `Id` (int, PK)
  - `Name` (string)
  - `Products` (collection of Product)
- **Product**
  - `Id` (int, PK)
  - `Name` (string)
  - `Price` (decimal)
  - `CategoryId` (int, FK to Category)

A Category can have multiple Products. Each Product belongs to a single Category.

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Setup
1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/repository-pattern-demo.git
   cd repository-pattern-demo/RepositoryPatternDemo
   ```
2. **Configure the database connection:**
   - Update the `ConnectionStrings:db` value in `RepositoryPatternDemo.WebAPI/appsettings.json` to match your PostgreSQL setup.
3. **Apply migrations:**
   ```bash
   dotnet ef database update --project RepositoryPatternDemo.DataAccess --startup-project RepositoryPatternDemo.WebAPI
   ```
4. **Run the API:**
   ```bash
   dotnet run --project RepositoryPatternDemo.WebAPI
   ```
5. **Access the API documentation:**
   - Open [https://localhost:7110/scalar](https://localhost:7110/scalar) (or the URL shown in your terminal) for Swagger/OpenAPI UI.

## API Endpoints

### Category
- `GET    /api/category`                — Get all categories
- `GET    /api/category/{id}`           — Get category by ID
- `GET    /api/category/with-products/{id}` — Get category by ID with its products
- `POST   /api/category`                — Create a new category
- `PUT    /api/category`                — Update a category
- `DELETE /api/category`                — Delete a category

### Product
- `GET    /api/product`                 — Get all products
- `GET    /api/product/{id}`            — Get product by ID
- `POST   /api/product`                 — Create a new product
- `PUT    /api/product`                 — Update a product
- `DELETE /api/product`                 — Delete a product

## Usage Examples

### Create a Category
```http
POST /api/category
Content-Type: application/json

{
  "name": "Electronics"
}
```

### Create a Product
```http
POST /api/product
Content-Type: application/json

{
  "name": "Smartphone",
  "price": 699.99,
  "categoryId": 1
}
```

### Get All Products
```http
GET /api/product
```

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
