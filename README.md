# Inventory Management System

Lightweight Inventory Management System (console) implemented with .NET 10.

## Overview

This repository contains a small console-based inventory management application intended for learning and small-scale usage. It implements a simple in-memory linked-list product store with file save/load, basic reporting and a text menu UI.

Goals:
- Provide a working .NET 10 example for inventory operations
- Keep the codebase small and easy to extend (reports, persistence, API)

## Features

- Add / Update / Delete products
- View inventory and generate a simple report
- Save to and load from file

## Prerequisites

- .NET 10 SDK: https://dotnet.microsoft.com
- A code editor (Visual Studio 2022/2026, Visual Studio Code) — recommended

Check your .NET SDK version:

```powershell
dotnet --version
```

The output should be a 10.x version.

## Getting Started

Run the console application from the repository root:

```powershell
dotnet run --project InventoryManagementSystem.csproj
```

Alternatively open `InventoryManagementSystem.slnx` in Visual Studio and run the project.

When running the app you'll see a menu with options:
- 1: Add Product
- 2: Update Product
- 3: Delete Product
- 4: View Inventory
- 5: Generate Report
- 6: Save to File
- 7: Load from File

## Project Structure

- InventoryManagementSystem.csproj — main console project
- Program.cs — application entry point
- MyInventorySystem.cs — console UI and user interactions
- InventoryManager.cs — core inventory logic (static manager)
- Product.cs — product model (linked-list node)
- docs/uml — PlantUML sources and rendered diagrams

## Configuration

This is a minimal console app and has no external configuration by default. If you add persistent storage or configuration files later, put them under appsettings.json or a config folder and document them here.

## Running Tests

There are no automated tests included currently. To add tests, create a test project and use `dotnet test`.

## Contributing

Contributions and suggestions are welcome. Recommended workflow:

1. Open an issue to discuss large changes or features.
2. Create a branch for your work: `git checkout -b feat/your-feature`.
3. Keep changes focused and add tests where possible.
4. Submit a pull request describing the change and motivation.

I'm open to suggestions — file feature requests, roadmap ideas, or small improvements via issues or PRs.

## Suggested Improvements (open to discussion)

- Add unit tests for InventoryManager operations
- Replace linked-list storage with a collection or database-backed repository
- Add a Web API or minimal UI for remote access
- Improve persistence format (JSON/SQLite) and error handling

## License

This project is licensed under the MIT License. See the LICENSE file for full text.

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

