# WAD.14384

This application was developed for Web Application module, as coursework portfolio project @ WIUT by student ID: 00014384
##Topic: Events Manager

## Prerequisites
- .NET Core SDK
- Node.js and Angular CLI

## Setup Instructions
1. Clone the repository.
2. Navigate to the project directory.
3. Run `dotnet restore` to install backend dependencies.
4. Run `npm install` to install frontend dependencies.
5. Update the database connection string in `appsettings.json`.
6. Run `dotnet ef database update` to apply migrations.
7. Run `dotnet run` to start the backend server.
8. Navigate to the `ClientApp` directory and run `ng serve` to start the frontend server.

## Features
- CRUD operations for Events and Attendees.
- Swagger API documentation.
- Responsive Single Page Application using Angular.
