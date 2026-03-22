# Principios Clean Code y recomendaciones en la nomenclatura de la Programación Orientada a Objetos  

### Declaración de atributos

_saldo --> manera de declarar un atributo de campo **privado**.
Saldo --> es otra manera de escribir un atributo no privado (mayúscula al inicio)

### Namespace

**Namespace**: Es un contenedor lógico utilizado para organizar clases, interfaces, estructuras y enumeraciones relacionadas. Permite agrupar las clases en uno o varios ensamblajes.

```c#
    namespace PilaresOPP.Models;
```

+ Por lo general, sigue la jerarquía de carpetas del proyecto (Proyecto.Carpeta). En este caso, indica que el archivo pertenece a la carpeta Models dentro del proyecto PilaresOOP.  
+ **File-Scoped (Ámbito de archivo)**: Al terminar en punto y coma (;) y no usar llaves {} para envolver todo el código, se declara que todo el contenido de ese archivo .cs pertenece a ese namespace automáticamente.  

### ¿Para qué sirve?  

+ **Organización del Código**: Agrupa lógicamente las clases del modelo (Modelos de datos), diferenciándolas de la lógica de negocio, controladores o vistas (MVC).  
+ **Evitar Conflictos de Nombres**: Permite tener dos clases con el mismo nombre en el mismo proyecto, siempre y cuando estén en namespaces diferentes. Por ejemplo, PilaresOOP.Models.Usuario y PilaresOOP.Data.Usuario.

Para usar esta clase en otro archivo (ej. Program.cs), necesitarás importarla usando:
**using PilaresOOP.Models**;
Ejemplo:

```c#
    // Persona.css
    namespace PilaresOOP.Models;

    public class Persona
    {
        public string Nombre { get; set; }
        // ...
    }
```

```c#
    // Program.css
    using PilaresOOP.Models;

```

 