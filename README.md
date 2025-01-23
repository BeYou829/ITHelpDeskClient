# Sistema de Gestión de Tickets

Este proyecto es un sistema de gestión de tickets desarrollado con **.NET 8.0**, **ASP.NET Core**, y **Entity Framework Core**. Permite a los usuarios crear, visualizar y gestionar tickets de manera eficiente.

## Requisitos previos

Antes de empezar, asegúrate de tener los siguientes requisitos instalados en tu sistema:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Git](https://git-scm.com/)
- Un IDE compatible, como [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)

## Configuración del proyecto

1. **Clonar el repositorio**  
   Clona este repositorio en tu máquina local utilizando el siguiente comando:
   ```bash
   git clone https://github.com/tu-usuario/sistema-gestion-tickets.git
   cd sistema-gestion-tickets

2. **Configurar la base de datos**
	"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TicketDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}			
    Nota: Reemplaza localhost con la dirección de tu servidor SQL y ajusta otros parámetros si es necesario.

3. **Aplicar las migraciones**
    dotnet ef database update

4. **Restaurar paquetes**
    dotnet restore

5. **Ejecutar la aplicación**
    Desde CLI: dotnet run
    Desce VS: F5