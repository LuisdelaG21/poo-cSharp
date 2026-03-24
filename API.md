# Proyecto APITest1

El siguiente proyecto fue realizado en Visual Studio Community 2022 y utiliza las extensiones de .NET para llevarlo a cabo.

Plugins utilizados:
+ ASP.NET
+ EntityFrameworkCore.SqlServer
+ EntityFrameworkCore.Tools

### Jeraquía de carpetas y clases

La jerarquía de los archivos del proyecto consta de la siguiente estructura:

- APITest1
    - Controllers (carpeta)
        - AutoresControllers.cs
    - Entidades (carpeta)
        - Autor.cs
    - appsettings.json
        - appsettings.Development.json (conexión con SQL Server)
    - Program.cs   

A continuación se muestran los códigos de cada clase en el orden en que fueron modificados o creados:

### 1. appsettings.Development.json (conexión con SQL Server)  

```c#
    {
    "ConnectionStrings": {
        "DefaultConnection": "Server=DESKTOP-M4C2JC1\\SQLEXPRESS;DataBase=DbTest;Integrated Security=True;TrustServerCertificate=True"
    },

    "Logging": {
        "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
        }
    }
    }
```

### 2. Program.cs 

```c#
    var builder = WebApplication.CreateBuilder(args);

    //area de servicios - 1
    builder.Services.AddControllers();

    var app = builder.Build();

    //area de middlawares - 2
    app.MapControllers();

    app.Run();
```  

### 3. Autor.cs

Creamos una carpeta llamada Entidades y dentro creamos la clase Autor.cs.

```c#
    namespace APITest1.Entidades
    {
        public class Autor
        {
            public int Id { get; set; }
            public required string Nombre { get; set; }
        }
    }
```

### 4. AutoresControllers.cs  

Creamos una carpeta llamada Controllers y dentro creamos la clase AutoresControllers.cs.

```c#
    using APITest1.Entidades;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using System.Data.SqlTypes;



    namespace APITest1.Controllers
    {
        [ApiController]
        [Route("api/autores")]
        public class AutoresControllers : ControllerBase //herencia de ControllerBase 
        {
            private readonly string? _connectionString;
            //ctor y tecla tab para agregar el constructor de la clase
            public AutoresControllers(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            [HttpGet] // Método Get
            public async Task<ActionResult<IEnumerable<Autor>>> GetConsultaADO() 
            {
                var autores = new List<Autor>();

                try
                {
                    using (SqlConnection oConn = new SqlConnection(_connectionString))
                    {
                        await oConn.OpenAsync();

                        using (SqlCommand oCmd = new SqlCommand("SELECT Id, Nombre From Autores", oConn))
                        {
                            oCmd.CommandType = System.Data.CommandType.Text;

                            using (SqlDataReader reader = await oCmd.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    autores.Add(new Autor
                                    {
                                        Id = (int)reader["Id"],
                                        Nombre = reader["Nombre"].ToString()
                                    });
                                }
                            }
                        }
                    }
                    return Ok(autores);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno: {ex.Message}");
                }
            }
        }
    }
```  

> Esta es la parte compleja que me interesa entender a la perfección.  

## Muestra de resultados

Cuando ejecutamos Programs.cs se abre el navegador con la dirección ip adquirida, luego colocamos la ruta específica al final: .../api/autores.

En el navegador aparece la siguiente información:

```json
[
  {
    "id": 1,
    "nombre": "Luis"
  },
  {
    "id": 2,
    "nombre": "Gamaliel"
  }
]
```

> Es esto el EndPoint?