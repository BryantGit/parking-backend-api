# Technical Interview Exercise

This repository contains the solution to the exercise proposed during a technical interview.

## Technologies Used

- Programming Language: C#
- Frameworks/Libraries:
  - .NET Core
  - Entity Framework
- Services and Configurations:
  - Microsoft SQL Server: NuGet Package `Microsoft.EntityFrameworkCore.SqlServer`
  - JWT Authentication: NuGet Package `Microsoft.AspNetCore.Authentication.JwtBearer`
  - Entity Framework Tools: NuGet Package `Microsoft.EntityFrameworkCore.Tools`

## Running the Application

To run the application successfully, follow these steps:

1. Authentication Token:
   - Enter the authentication token with the following data:
     - Username: prueba@prueba.com
     - Password: 123
   - Once the token is generated, enter it in the authentication header using the format: `'Bearer [token]'`.

     Example: `'Bearer 12345abcdef'`

2. User Creation:
   - When creating a new user, there is no need to add the ID, as an auto-incremented ID was used in this example.

## Development Steps

To develop the application, follow these steps:

1. Design and Model the Database in SQL Server:
   - Design and model the database in SQL Server according to the project requirements.

2. Export Models with Entity Framework:
   - Use Entity Framework to export models from the database.

3. Generate Connection String:
   - Configure the connection string in the application to connect to the database.

4. Create Relevant Controllers:
   - Develop the necessary controllers to handle the application's operations.

## API Link

Link: [API](http://www.apiparking.somee.com/swagger/index.html)
https://www.apiparking.somee.com/swagger/index.html (authentication process in progress)
