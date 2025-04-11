# Sistema de Gesti�n de Tickets

Este proyecto es un sistema de gesti�n de tickets desarrollado con **.NET 8.0**, **ASP.NET Core**, y **Entity Framework Core**. Permite a los usuarios crear, visualizar y gestionar tickets de manera eficiente.

## Requisitos previos

Antes de empezar, aseg�rate de tener los siguientes requisitos instalados en tu sistema:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Git](https://git-scm.com/)
- Un IDE compatible, como [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)

## Configuraci�n del proyecto

1. **Clonar el repositorio**  
   Clona este repositorio en tu m�quina local utilizando el siguiente comando:
   ```bash
   git clone https://github.com/tu-usuario/sistema-gestion-tickets.git
   cd sistema-gestion-tickets

2. **Configurar la base de datos**
	"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TicketDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}			
    Nota: Reemplaza localhost con la direcci�n de tu servidor SQL y ajusta otros par�metros si es necesario.

3. **Aplicar las migraciones**
    dotnet ef database update

4. **Restaurar paquetes**
    dotnet restore

5. **Ejecutar la aplicaci�n**
    Desde CLI: dotnet run
    Desce VS: F5