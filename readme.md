## Instalación de .NET en Arch Linux

Para desarrollar y trabajar con C# y .NET en Arch Linux, necesitarás instalar los siguientes tres paquetes:

```bash
sudo pacman -S dotnet-sdk        # Kit de desarrollo de .NET (SDK)
sudo pacman -S dotnet-runtime    # Runtime de .NET para ejecutar aplicaciones
sudo pacman -S aspnet-runtime    # Runtime de ASP.NET Core para aplicaciones web/API
```


## Instalación de SQL Server en Linux mediante Docker

Dado que SQL Server no tiene soporte nativo para Linux, puedes utilizar Docker para correr un contenedor con SQL Server.

### Descargar la imagen de SQL Server:

```bash
sudo docker pull mcr.microsoft.com/mssql/server:2022-latest
```

### Correr el contenedor:

```bash
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<YourPassword>' -p 1433:1433 --name sql_server_container -d mcr.microsoft.com/mssql/server:2022-latest
```

- **SA_PASSWORD**: Reemplaza `<YourPassword>` con la contraseña que quieras asignar.
- **Usuario**: El usuario por defecto será `sa`.

---

## Ejecutar el proyecto .NET

Para correr el proyecto, usa el siguiente comando:

```bash
dotnet run
```

Si deseas que los cambios se actualicen en tiempo real durante el desarrollo, puedes utilizar el siguiente comando:

```bash
dotnet watch run
```

---

## Entity Framework para el mapeo de tablas

Con **Entity Framework**, puedes mapear automáticamente las tablas de la base de datos a modelos en tu aplicación, lo que te ahorrará tiempo al no tener que escribir los modelos manualmente.


Para desgarlo puedes hacer
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
``` 
Para poder generar los modelos a partir de la base de datos, también necesitarás las herramientas de Entity Framework Core:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

Si estás usando Migrations (migraciones), también es recomendable agregar este paquete:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Para poder mapear los mo    delos desde las tablas de la base, puedes hacer esto:

```bash
    dotnet ef dbcontext scaffold "Server=localhost;Database=api_cs_test;User Id=sa;Password=<YourPassword>;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models
```

pero para tener disponible este comando debes de descargar y configurar estos dos comandos:

```bash 
dotnet new tool-manifest
```

Y instalar dotnet-ef        
```bash
dotnet tool install --global dotnet-ef
```


---
