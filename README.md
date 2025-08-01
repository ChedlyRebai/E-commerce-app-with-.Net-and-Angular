# E-commerce Application with .NET and Angular

A full-stack e-commerce application built with .NET 8 Web API backend and Angular 17 frontend, following clean architecture principles.

## 🏗️ Architecture

This project follows Clean Architecture with the following structure:

### Backend (.NET 8)
- **Api** - Web API controllers and presentation layer
- **Core** - Business logic, entities, and abstractions
- **Infrastructure** - Data access, external services, and implementations

### Frontend (Angular 17)
- **client** - Angular application with modern UI/UX

## 🚀 Features

- **Product Management** - Browse and manage product catalog
- **Shopping Cart** - Add/remove products, manage basket
- **User Authentication** - Register/login functionality
- **Order Management** - Place and track orders
- **Category Management** - Organize products by categories
- **Image Management** - Upload and manage product images
- **Email Services** - Automated email notifications
- **Responsive Design** - Mobile-friendly interface

## 🛠️ Technology Stack

### Backend
- .NET 8 Web API
- Entity Framework Core
- ASP.NET Core Identity
- AutoMapper
- Swagger/OpenAPI
- CORS support

### Frontend
- Angular 17
- TypeScript
- Tailwind CSS
- Angular CLI

### Database
- SQL Server (configurable)

## 📋 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18+)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)
- SQL Server or SQL Server Express

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/ChedlyRebai/E-commerce-app-with-.Net-and-Angular.git
cd E-commerce-app-with-.Net-and-Angular
```

### 2. Backend Setup

#### Install Dependencies
```bash
dotnet restore
```

#### Update Database Connection
Update the connection string in `Api/appsettings.json` and `Api/appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EcommerceDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

#### Run Database Migrations
```bash
dotnet ef database update --project Infrastructure --startup-project Api
```

#### Start the API
```bash
cd Api
dotnet run
```
The API will be available at `https://localhost:5001` or `http://localhost:5000`

### 3. Frontend Setup

#### Navigate to Client Directory
```bash
cd client
```

#### Install Dependencies
```bash
npm install
```

#### Start Development Server
```bash
ng serve
```
The Angular application will be available at `http://localhost:4200`

## 📁 Project Structure

```
├── Api/                          # Web API project
│   ├── Controllers/              # API controllers
│   ├── Middleware/              # Custom middleware
│   ├── Helper/                  # Helper classes
│   └── wwwroot/Images/         # Static image files
├── Core/                        # Core business logic
│   ├── Entities/               # Domain entities
│   ├── DTO/                    # Data transfer objects
│   ├── Interfaces/             # Repository interfaces
│   ├── Services/               # Service interfaces
│   └── Shared/                 # Shared classes
├── Infrastructure/             # Data access layer
│   ├── Data/                   # DbContext and configurations
│   ├── Repositories/           # Repository implementations
│   └── Migrations/             # EF Core migrations
└── client/                     # Angular application
    └── src/
        ├── app/               # Angular components and services
        └── assets/            # Static assets
```

## 🔧 Configuration

### Backend Configuration
Key configuration files:
- `Api/appsettings.json` - Production settings
- `Api/appsettings.Development.json` - Development settings

### Frontend Configuration
- `client/src/environments/` - Environment-specific settings

## 🐛 API Testing

The project includes HTTP files for testing API endpoints:
- `Api/Api.http` - Contains sample API requests

You can also access the Swagger UI at `https://localhost:5001/swagger` when running the API.

## 🤝 Contributing

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

## 📧 Contact

Project Link: [https://github.com/ChedlyRebai/E-commerce-app-with-.Net-and-Angular](https://github.com/ChedlyRebai/E-commerce-app-with-.Net-and-Angular)

## 🙏 Acknowledgments

- Built with [.NET 8](https://dotnet.microsoft.com/)
- Frontend powered by [Angular 17](https://angular.io/)
- Styled with [Tailwind CSS](https://tailwindcss.com/)
