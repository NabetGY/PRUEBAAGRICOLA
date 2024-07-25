# Proyecto ASP.NET Core: Web API y MVC

Este repositorio contiene una solución de ASP.NET Core con dos proyectos:

- **Web API**: Proporciona endpoints para operaciones CRUD.
- **MVC**: Interfaz de usuario que consume la API.

## Requisitos Previos

Antes de configurar y ejecutar el proyecto, asegúrate de tener instalados los siguientes componentes:

- [.NET SDK 8.0] Este proyecto utiliza .NET 8.0. Descarga e instala el SDK si aún no lo tienes.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) Este proyecto SQL Server Descarga e instala una base de datos SQL Server.

## Configuración del Proyecto

### 1. Clonar el Repositorio

Clona este repositorio en tu máquina local utilizando Git:

```bash
git clone https://github.com/tu_usuario/tu_repositorio.git

### 2. Configurar el Entorno de Desarrollo

Navega al directorio del proyecto:

cd PRUEBAAGRICOLA

### 3. Configurar la Base de Datos

asegúrate de configurar correctamente la cadena de conexión en el archivo appsettings.json de cada proyecto.

Web API:

Abre el archivo appsettings.json en el proyecto Web API.

Busca la sección ConnectionStrings y ajusta la cadena de conexión a tu base de datos:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TuBaseDeDatos;User Id=tu_usuario;Password=tu_contraseña;"
  }
}

### 4. Restaurar Dependencias
Restaura las dependencias de ambos proyectos ejecutando el siguiente comando en la raíz del proyecto:

dotnet restore

### 5. Migrar la Base de Datos
Entity Framework Core, aplica las migraciones para configurar la base de datos:

Dirígete al proyecto de la API web:

cd src/Api

Aplica las migraciones:

dotnet ef database update

### 6. Ejecutar el Proyecto
Ejecutar la API Web
Navega al directorio del proyecto de la API Web:

cd src/Api

Inicia el servidor de desarrollo:

dotnet run

Ejecutar la Aplicación MVC
Abre un nuevo terminal o vuelve al directorio raíz del proyecto.

Navega al directorio del proyecto MVC:


cd src/mvc

Inicia el servidor de desarrollo:

dotnet run

Licencia
Este proyecto está licenciado bajo la MIT License.

Autor
NabetG


