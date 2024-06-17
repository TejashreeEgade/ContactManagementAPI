# ContactManagementAPI
API for CRUD Operation - Contact Management System


This is the backend API of the application built using .NET Core 8.

## Table of Contents

- [Setup Instructions](#setup-instructions)
- [How to Run the Application](#how-to-run-the-application)
- [Design Decisions and Application Structure](#design-decisions-and-application-structure)

## Setup Instructions

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

### Steps

1. Clone the repository:
    ```sh
    git clone https://github.com/TejashreeEgade/ContactManagementAPI.git
    cd ContactManagementAPI/ContactManagementAPI
    ```

2. Restore the .NET dependencies:
    ```sh
    dotnet restore
    ```

3. Build the project:
    ```sh
    dotnet build
    ```

## How to Run the Application

1. Navigate to the project directory:
    ```sh
    cd ContactManagementAPI
    ```

2. Run the application:
    ```sh
    dotnet run
    ```

3. The API will be available at `https://localhost:7216`


### Design Decisions

- **Framework:** Chose .NET Core 8 for its performance, scalability, and support for modern web APIs.
- **Architecture:** Followed a clean architecture pattern, separating concerns across different layers (API, Services, Data Access).
- **Authentication:** Implemented JWT (JSON Web Token) based authentication for secure and stateless communication.
- **Database:** Using Entity Framework Core for ORM (Object-Relational Mapping) and SQL Server as the database provider.