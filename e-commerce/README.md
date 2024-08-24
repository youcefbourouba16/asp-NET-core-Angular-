
# Project Name

## Overview
![1](https://github.com/user-attachments/assets/f91019dc-577e-4ce2-b1ce-46045eb6d8fe)
![2](https://github.com/user-attachments/assets/60ca8c5a-7ef2-4351-9505-f280fd271e17)
![3](https://github.com/user-attachments/assets/764d3f05-2b48-4fda-a79e-06342050802f)
![4](https://github.com/user-attachments/assets/94e4966f-ec33-4031-88ee-1e0dbc7da0cc)

This project is a web application built using Angular, ASP.NET Core, and SQL Server. The frontend is powered by Angular 16.2.14, while the backend is developed with the latest version of ASP.NET Core, utilizing Entity Framework Core for both database interactions and authentication. Cloudinary is used for media management and storage.

## Features

- **Frontend:** Angular 16.2.14
- **Backend:** ASP.NET Core (latest version)
- **Database:** SQL Server with Entity Framework Core
- **Authentication:** Entity Framework Core for user management and authentication
- **Media Management:** Cloudinary for storing and managing media assets
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

2. **Set up `app.config`, `appsettings.json`, and Cloudinary:**

   Ensure you have configured the `app.config` and `appsettings.json` files with the necessary settings, including your SQL Server connection string, Cloudinary credentials, authentication settings, and any other environment-specific configurations.

   Example Cloudinary configuration in `appsettings.json`:
   ```json
   "Cloudinary": {
     "CloudName": "your_cloud_name",
     "ApiKey": "your_api_key",
     "ApiSecret": "your_api_secret"
   }
   ```

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

## Authentication

This project uses Entity Framework Core for authentication. Ensure that your authentication settings are correctly configured in your `Startup.cs` or `Program.cs` file (depending on your .NET version). You will need to set up your identity models and configure the authentication services.

## Cloudinary Integration

This project uses Cloudinary for media management and storage. Ensure that your Cloudinary settings are properly configured in the `appsettings.json` file, and integrate Cloudinary SDKs into your project as needed for uploading and managing media.

## Contributing

Contributions are welcome! Please submit a pull request for any changes you would like to see.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
