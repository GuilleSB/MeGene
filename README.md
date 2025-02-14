# 📌 Generador de Código C# desde SQL Server

## 📖 Descripción
Este proyecto es un generador de código que permite convertir estructuras de tablas en **SQL Server** en **modelos C#**. La aplicación sigue una arquitectura **modular y escalable**, permitiendo futuras mejoras e integraciones.

## 🚀 Características
✅ **Obtención Dinámica de Esquemas**: Listado de bases de datos, schemas y tablas desde un servidor SQL Server.  
✅ **Generación Automática de Modelos C#**: Traducción de la estructura de tablas a clases en C# con anotaciones de Entity Framework.  
✅ **API Segura y Modular**: Controladores y servicios separados para una mejor organización y escalabilidad.  
✅ **Middleware de Manejo de Errores**: Implementación de un sistema estandarizado para respuestas y manejo de excepciones.

## 📂 Estructura del Proyecto
```
MeGeneAPI/
│── Controllers/
│   ├── DatabaseController.cs    # Manejo de bases de datos, schemas y tablas.
│   ├── ModelGeneratorController.cs  # Generación de modelos C#.
│
│── Interfaces/
│   ├── IDatabaseRepository.cs
│   ├── IDatabaseService.cs
│   ├── IModelGeneratorService.cs
│
│── Middleware/
│   ├── ExceptionMiddleware.cs    # Manejo de excepciones globales.
│
│── Models/
│   ├── ApiResponse.cs           # Modelo de respuestas estándar.
│   ├── DatabaseRequests.cs      # Modelos para solicitudes API.
│   ├── TableColumn.cs           # Estructura de columnas en una tabla SQL.
│
│── Repositories/
│   ├── DatabaseRepository.cs    # Acceso a datos con ADO.NET.
│
│── Services/
│   ├── DatabaseService.cs       # Lógica de base de datos.
│   ├── ModelGeneratorService.cs # Generación de código C#.
│
│── appsettings.json             # Configuraciones del proyecto.
│── Program.cs                   # Configuración de la API.
│── MeGeneAPI.csproj              # Archivo de configuración del proyecto.
```

## 🔧 Instalación y Uso
### **1️⃣ Clonar el Repositorio**
```bash
git clone https://github.com/tuusuario/MeGeneAPI.git
cd MeGeneAPI
```

### **2️⃣ Configurar la Conexión a SQL Server**
Editar el archivo `appsettings.json` con la conexión a la base de datos:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=MI_SERVIDOR;Database=MI_BASE;User Id=USUARIO;Password=CLAVE;"
  }
}
```

### **3️⃣ Ejecutar el Proyecto**
```bash
dotnet build
dotnet run
```
La API estará disponible en `http://localhost:5000/swagger`.

## 🔥 Endpoints Disponibles
### **📌 Obtener Bases de Datos**
```http
POST /api/database/list
```
**Body:**
```json
{
  "connectionString": "Server=MI_SERVIDOR;User Id=USUARIO;Password=CLAVE;"
}
```

### **📌 Obtener Schemas de una Base de Datos**
```http
POST /api/database/schemas
```
**Body:**
```json
{
  "connectionString": "Server=MI_SERVIDOR;User Id=USUARIO;Password=CLAVE;",
  "database": "MiBase"
}
```

### **📌 Obtener Tablas de un Schema**
```http
POST /api/database/tables
```
**Body:**
```json
{
  "connectionString": "Server=MI_SERVIDOR;User Id=USUARIO;Password=CLAVE;",
  "database": "MiBase",
  "schema": "Ventas"
}
```

### **📌 Generar Código C# para una Tabla**
```http
POST /api/model/generate
```
**Body:**
```json
{
  "connectionString": "Server=MI_SERVIDOR;User Id=USUARIO;Password=CLAVE;",
  "database": "MiBase",
  "schema": "Ventas",
  "table": "Ordenes"
}
```

## 📜 Licencia
Este proyecto está bajo la **MIT License**.

## ✨ Contribuciones
¡Las contribuciones son bienvenidas! Si quieres mejorar el proyecto, abre un PR o sugiere cambios en Issues.

📌 **Autor**: Guillermo Sotomayor Blanco  
🚀 **LinkedIn**: [gu99sotob](www.linkedin.com/in/gu99sotob)  

