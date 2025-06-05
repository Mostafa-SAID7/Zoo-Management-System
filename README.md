# 🦁 Zoo Management System

A **simple Zoo Management System** implemented in **C#** to manage animals and staff with basic CRUD operations and listing features.

---

## 📖 Description

This project demonstrates the core functionality of a Zoo Management System with the ability to:

- Add and manage animals (name, species, age, enclosure)
- Add and manage staff members (name, role, contact)
- List all animals and staff in the system

The current implementation is a **console-based prototype** showcasing object-oriented design and basic operations. It can be extended to support GUI or web interfaces and database storage.

---

## 🚀 Features

- ✅ Add new animals and staff  
- ✅ Display lists of animals and staff  
- ✅ Simple class structure with `Animal`, `Staff`, and `ZooManagement` classes  

---

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

- Animal.cs - Defines the Animal class
- Staff.cs - Defines the Staff class
- ZooManagement.cs - Contains the management logic for animals and staff
- Program.cs - Entry point with demo usage

### Future Improvements

- Add editing and deleting animals and staff
- Implement persistent storage using a database
- Create a GUI with Windows Forms, WPF, or ASP.NET Core
- Add user authentication and role-based access
- Extend functionality to manage feeding schedules, health records, and ticketing

### License
This project is open-source and available under the MIT License.
