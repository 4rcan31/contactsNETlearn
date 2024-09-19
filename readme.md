---

## Instalación de .NET en Arch Linux

Para desarrollar y trabajar con C# y .NET en Arch Linux, necesitarás instalar los siguientes tres paquetes:

```bash
sudo pacman -S dotnet-sdk        # Kit de desarrollo de .NET (SDK)
sudo pacman -S dotnet-runtime    # Runtime de .NET para ejecutar aplicaciones
sudo pacman -S aspnet-runtime    # Runtime de ASP.NET Core para aplicaciones web/API
```

---

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

---
