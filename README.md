# 🦁 Zoo Management System

A console-based application written in C# to help manage a zoo’s animals, enclosures, feeding schedules, and medical records.

---

## 📖 Description

This project demonstrates the core functionality of a Zoo Management System with the ability to:

- Add and manage animals (name, species, age, enclosure)
- Add and manage staff members (name, role, contact)
- List all animals and staff in the system

The current implementation is a **console-based prototype** showcasing object-oriented design and basic operations. It can be extended to support GUI or web interfaces and database storage.

---

## 🚀 Features

- Add and manage enclosures with capacity limits
- Add animals to enclosures and transfer animals between enclosures
- Search animals by name or species
- Manage medical records for each animal (add/view diagnosis and treatment history)
- Set and update feeding schedules (food type and feeding time) per animal
- Save and load data persistently using JSON files

---
## Data Persistence

All zoo data (enclosures, animals, feeding schedules, medical records) are saved in JSON format under the Data/zoo_data.json file automatically when you choose “Save & Exit” from the menu.

## 🛠️ Getting Started

### Prerequisites

- <a href="https://dotnet.microsoft.com/download" target="_blank">
    <img src="https://img.shields.io/badge/.NET_SDK-6.0-blue?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET SDK Download"/>
  </a> (version 6.0 or higher recommended)  
- A C# IDE or editor like Visual Studio, Visual Studio Code, or Rider  

### Running the Project

1. Clone the repository or copy the source files into a C# project.
2. Build the project using your IDE or via command line:
```
dotnet build
```
#### Run the project:
```
dotnet run
```
The console app will demonstrate adding some animals and staff, then listing them.

### Project Structure

- `Program.cs` — Entry point of the application
- `Models/` — Contains data models:
  - `Animal.cs`
  - `Enclosure.cs`
  - `FeedingSchedule.cs`
  - `MedicalRecord.cs`
  - `Zookeeper.cs` (reserved for future expansion)
- `Services/` — Core business logic and UI handling:
  - `ZooManager.cs` — Manages all zoo operations
  - `MenuService.cs` — Console menu and user interaction
  - `DataService.cs` — Handles JSON data load/save operations

### Future Improvements

- Add editing and deleting animals and staff
- Implement persistent storage using a database
- Create a GUI with Windows Forms, WPF, or ASP.NET Core
- Add user authentication and role-based access
- Extend functionality to manage feeding schedules, health records, and ticketing

### License
This project is open-source and available under the MIT License.
