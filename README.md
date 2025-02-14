# 📌 C# Code Generator from SQL Server

## 📖 Description
This project is a code generator that converts **SQL Server** table structures into **C# models**. The application follows a **modular and scalable architecture**, allowing future improvements and integrations.

## 🚀 Features
✅ **Dynamic Schema Retrieval**: Fetch databases, schemas, and tables from an SQL Server instance.  
✅ **Automatic C# Model Generation**: Translates table structures into C# classes with Entity Framework annotations.  
✅ **Secure and Modular API**: Separate controllers and services for better organization and scalability.  
✅ **Exception Handling Middleware**: Standardized system for error handling and API responses.

## 📂 Project Structure
```
MeGeneAPI/
│── Controllers/
│   ├── DatabaseController.cs    # Handles databases, schemas, and tables.
│   ├── ModelGeneratorController.cs  # Handles C# model generation.
│
│── Interfaces/
│   ├── IDatabaseRepository.cs
│   ├── IDatabaseService.cs
│   ├── IModelGeneratorService.cs
│
│── Middleware/
│   ├── ExceptionMiddleware.cs    # Global exception handling.
│
│── Models/
│   ├── ApiResponse.cs           # Standard API response model.
│   ├── DatabaseRequests.cs      # Models for API requests.
│   ├── TableColumn.cs           # Table column structure for SQL.
│
│── Repositories/
│   ├── DatabaseRepository.cs    # Data access using ADO.NET.
│
│── Services/
│   ├── DatabaseService.cs       # Database logic.
│   ├── ModelGeneratorService.cs # C# code generation.
│
│── appsettings.json             # Project configurations.
│── Program.cs                   # API setup.
│── MeGeneAPI.csproj              # Project configuration file.
```

## 🔧 Installation and Usage
### **1️⃣ Clone the Repository**
```bash
git clone https://github.com/yourusername/MeGeneAPI.git
cd MeGeneAPI
```

### **2️⃣ Run the Project**
```bash
dotnet build
dotnet run
```
The API will be available at `http://localhost:5000/swagger`.

## 🔥 Available Endpoints
### **📌 Get Databases**
```http
POST /api/database/list
```
**Body:**
```json
{
  "connectionString": "Server=MY_SERVER;User Id=USER;Password=PASSWORD;"
}
```

### **📌 Get Schemas from a Database**
```http
POST /api/database/schemas
```
**Body:**
```json
{
  "connectionString": "Server=MY_SERVER;User Id=USER;Password=PASSWORD;",
  "database": "MyDatabase"
}
```

### **📌 Get Tables from a Schema**
```http
POST /api/database/tables
```
**Body:**
```json
{
  "connectionString": "Server=MY_SERVER;User Id=USER;Password=PASSWORD;",
  "database": "MyDatabase",
  "schema": "Sales"
}
```

### **📌 Generate C# Model from a Table**
```http
POST /api/model/generate
```
**Body:**
```json
{
  "connectionString": "Server=MY_SERVER;User Id=USER;Password=PASSWORD;",
  "database": "MyDatabase",
  "schema": "Sales",
  "table": "Orders"
}
```

## 📜 License
This project is licensed under the **MIT License**.

## ✨ Contributions
Contributions are welcome! If you want to improve the project, submit a PR or suggest changes in the Issues section.

📌 **Author**: Guillermo Sotomayor Blanco  

