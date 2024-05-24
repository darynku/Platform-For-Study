# ASP.NET Core Web API with EF Core and Clean Architecture

This project is a web API built using ASP.NET Core Web API version 8.0, Entity Framework Core, and the Clean Architecture pattern.

## Contents

- [Description](#description)
- [Technologies](#technologies)
- [Installation](#installation)
- [Usage](#usage)


## Description

This project is a platform for creating courses and lessons. It includes authentication and authorization based on JWT (JSON Web Tokens).

## Technologies

The project uses the following technologies:

- **ASP.NET Core Web API 8.0**: For building the web API.
- **Entity Framework Core**: For database interactions.
- **Clean Architecture**: For structuring the project.
- **JWT Authentication and Authorization**: For securing the API.


## Installation

1. **Clone the repository**:
    ```sh
    git clone https://github.com/yourusername/your-repository.git
    cd your-repository
    ```

2. **Set up the database**:
    - Update the connection string in `appsettings.json`.
    - Apply migrations:
        ```sh
        dotnet ef database update
        ```

3. **Run the application**:
    ```sh
    dotnet run
    ```

## Usage

- Access the API at `http://localhost:5000`.
- Use tools like Postman or Swagger to interact with the endpoints.

### Authentication

- The API uses JWT for authentication. Obtain a token by logging in and include it in the `Authorization` header of your requests.
