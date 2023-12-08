# Student Management System Project

## Overview

Welcome to the Student Management System, a .NET Core project with a Razor Pages frontend and a SQL backend. This system is designed to revolutionize the student experience by providing a centralized platform for academic management, university updates, and career exploration.

## Features

1. **Academic Control:**
   - Effortlessly manage find courses, course registrations, and schedules.

2. **University Updates:**
   - Stay in the loop with important announcements and news directly from the university.

3. **Library Management:**
   - Explore a wide variety of books and borrow books online.

4. **Career Possibilities:**
   - Discover and pursue career opportunities through job postings and internship information.

## Technology Stack

- **Backend:** .NET Core 7,C#
- **Frontend:** Razor Pages,HTML/CSS,Bootstrap
- **Database:** MIcrosoft SQL Server

## Getting Started

### Prerequisites

- Install [.NET Core SDK](https://dotnet.microsoft.com/download) on your machine.
- Set up a SQL Server instance or connection for the project's database.

### Installation Steps

1. **Download the project**

   - Download the project zip file
   - Unzip the file and open Solution Explorer to open the project

2. **Update the database connection string:**
   - Open the `appsettings.json` file in the project.
   - Replace the default connection string with your SQL Server connection details.

3. **Run the migrations to create the database:**

   ```bash
   dotnet ef database update
   ```

4. **Build and run the project:**

   ```bash
   dotnet build
   dotnet run
   ```

5. **Access the application:**
   - Open your web browser and go to [http://localhost:7250](http://localhost:7250).

## Acknowledgments

- Special thanks to the .NET Core and Razor Pages communities for their valuable contributions and support.
- Inspired by the mission to enhance the overall student experience in academic institutions.
