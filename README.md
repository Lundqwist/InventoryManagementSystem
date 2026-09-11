# Inventory Management System

Lightweight Inventory Management System built with .NET 10.

## Overview

This project provides a simple inventory management application intended for educational and small business use. It includes core functionality for tracking products, stock levels, and basic inventory operations.

Key goals:
- Demonstrate a clean .NET 10 project structure
- Provide a starting point for extending inventory features (reports, users, integrations)

## Features

- Product CRUD (Create, Read, Update, Delete)
- Stock tracking and adjustments
- Basic reporting and console / UI entry points (depending on included projects)

## Prerequisites

- .NET 10 SDK (install from https://dotnet.microsoft.com)
- Visual Studio 2022 or newer (recommended) or Visual Studio Code

Verify your .NET SDK version:

```powershell
dotnet --version
```

The output should report a 10.x version.

## Getting Started

Open the solution in Visual Studio:

1. Open `InventoryManagementSystem.slnx` in Visual Studio.
2. Set your startup project and run (F5) or build (Ctrl+Shift+B).

Or use the .NET CLI:

```powershell
cd path\to\InventoryManagementSystem
dotnet build
dotnet run --project src/YourStartupProject/YourStartupProject.csproj
```

Replace `src/YourStartupProject/YourStartupProject.csproj` with the actual project file you intend to run (for example a console app or web API project in the solution).

## Project Structure

- src/ - main application projects
- tests/ - unit and integration tests (if present)
- docs/ - documentation (optional)

Adjust paths to match the repository layout if different.

## Configuration

Application configuration is typically stored in appsettings.json for ASP.NET projects or other project-specific configuration files. Check each project for its own configuration file and update connection strings, logging, and other settings before running in a production environment.

## Running Tests

If the repository contains tests, run them with:

```powershell
dotnet test
```

## Contributing

Contributions are welcome. Open an issue to discuss changes or submit a pull request. Keep changes focused, include tests for new behavior, and follow existing code style patterns.

## License

This project is licensed under the MIT License - see the LICENSE section below.

---

MIT License

Copyright (c) 2026 Lundqwist

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
