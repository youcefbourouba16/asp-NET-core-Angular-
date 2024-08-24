
# Project Name

## Overview

This project is a web application built using Angular, ASP.NET Core, and SQL Server. The frontend is powered by Angular 16.2.14, while the backend is developed with the latest version of ASP.NET Core, utilizing Entity Framework Core for database interactions.

## Features

- **Frontend:** Angular 16.2.14
- **Backend:** ASP.NET Core (latest version)
- **Database:** SQL Server with Entity Framework Core
- **Node.js:** Version 20

## Prerequisites

Ensure you have the following installed on your development machine:

- [Node.js](https://nodejs.org/) (version 20)
- [Angular CLI](https://angular.io/cli)
- [.NET SDK](https://dotnet.microsoft.com/download) (latest version)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/)

## Getting Started

### Backend

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/your-repository-name.git
   cd your-repository-name
   ```

2. **Set up `app.config` and `appsettings.json`:**

   Ensure you have configured the `app.config` and `appsettings.json` files with the necessary settings, including your SQL Server connection string and any other environment-specific configurations.

3. Restore .NET dependencies:
   ```bash
   dotnet restore
   ```

4. Update the database:
   ```bash
   dotnet ef database update
   ```

5. Run the backend:
   ```bash
   dotnet run
   ```

### Frontend

1. Navigate to the `ClientApp` directory:
   ```bash
   cd ClientApp
   ```

2. Install npm packages:
   ```bash
   npm install
   ```

3. Run the Angular application:
   ```bash
   ng serve
   ```

4. Open your browser and navigate to `http://localhost:4200`.

## Database Setup

This project uses SQL Server. Ensure your connection string is properly configured in the `appsettings.json` file in the root of the project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
}
```

## Entity Framework Migrations

To add a new migration:

```bash
dotnet ef migrations add MigrationName
```

To update the database with the latest migration:

```bash
dotnet ef database update
```

## Contributing

Contributions are welcome! Please submit a pull request for any changes you would like to see.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
