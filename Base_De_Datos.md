# Base de datos DBTest  

A continuación se muestra el Query de la base de datos que se utiliza para el proyecto APITest1 en .NET con Visual Studio Community.

Esta base de datos fue creada en SQL Server 2025.

```sql
    Create Database DbTest

    Use DbTest
    Create Table Autores
    (
        Id int Identity (1,1), --El identificador inicia en 1 y se incrementa en 1 ---
        Nombre Varchar(80),
        Primary Key (Id)
    )

    Insert Into Autores (Nombre)
    Values ('Luis')

    Insert Into Autores (Nombre)
    Values ('Gamaliel')
```
