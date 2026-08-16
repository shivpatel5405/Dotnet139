# Tourism App

## DESCRIPTION

A comprehensive web application for booking travel destinations, built with ASP.NET Core MVC and MySQL. This application allows users to register, log in, browse various travel destinations with detailed descriptions and images, create bookings with personal details, and confirm their reservations. It includes an admin panel for managing destinations, bookings, and user information. The app features a responsive design using Bootstrap, ensuring a seamless experience on both mobile and desktop devices. It utilizes Entity Framework Core with MySQL for robust data management and supports secure user authentication.

## INSTALLATION STEPS

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   cd "Tourism App"
   ```

2. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

3. **Set up the database**:
   - Create a MySQL database named `tourismapp`
   - Import the `tourismapp.sql` file to set up tables and initial data
   - Update the connection string in `appsettings.json` if needed

## HOW TO RUN PROJECT

4. **Run the application**:
   ```bash
   dotnet run
   ```

5. **Access the application**:
   Open your browser and navigate to `https://localhost:5001` (or the port shown in the console)

## Features

- **User Authentication**: Login and registration system
- **Destination Management**: Browse and view travel destinations with images and descriptions
- **Booking System**: Create and confirm bookings with personal details
- **Admin Panel**: Administrative interface for managing the application
- **Responsive Design**: Bootstrap-based UI for mobile and desktop

## Technologies Used

- **Backend**: ASP.NET Core 9.0 MVC
- **Database**: MySQL with Entity Framework Core
- **Frontend**: Razor Views, Bootstrap 5, jQuery
- **ORM**: Entity Framework Core with Pomelo MySQL provider

## Prerequisites

- .NET 9.0 SDK
- MySQL Server
- Node.js (for any frontend dependencies, if applicable)

## Database Configuration

The application uses MySQL as the database. The connection string is configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=tourismapp;User=root;Password=;"
  }
}
```

Update the connection string with your MySQL server details.

## Project Structure

- **Controllers/**: MVC controllers for handling requests
- **Models/**: Entity models and view models
- **Views/**: Razor views for the UI
- **Data/**: Database context and configurations
- **wwwroot/**: Static files (CSS, JS, images)
- **Migrations/**: Entity Framework migrations

## Key Models

- **User**: User accounts with authentication
- **Destination**: Travel destinations with pricing
- **Booking**: Booking records with user and destination references

## Usage

1. **Register/Login**: Create an account or log in
2. **Browse Destinations**: View available travel destinations
3. **Create Booking**: Fill in personal details and book a destination
4. **Booking Confirmation**: View booking details and confirmation

## Admin Features

- Access admin panel at `/Admin`
- Manage destinations and bookings
- View user information

## Development

To run in development mode:

```bash
dotnet watch run
```

This will start the application with hot reload enabled.

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## License

This project is licensed under the MIT License.
