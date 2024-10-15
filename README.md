# Jwt

This project is a .NET 8 web application that implements JWT authentication. It includes user login functionality and uses SQL Server for data storage.

## Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio or any C# compatible IDE

## Getting Started

1. **Clone the Repository**:
 
   ```bash
   
   git clone https://github.com/AhmetSulu/Jwt.git
   cd jwt
   
2. **Configure the database connection**:
 
    ```bash
    
   - Update the connection string in `appsettings.json`:
    
     "ConnectionStrings": {
     "Default": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
       },
     "Jwt": {
       "Key": "your_secret_key",
       "Issuer": "your_issuer",
       "Audience": "your_audience"
       }

3. **Run database migrations**:
  
    ```bash
    
    dotnet ef database update

4. **Run the application**:
   
   ```bash
   
    dotnet run

## Features

- User login with JWT authentication
- Secure API endpoints
- Swagger for API documentation

## Endpoints

- `POST /api/auth/login`: User login endpoint

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any questions or support, please email ahmet.sulu1993@gmail.com
