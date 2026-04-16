# Principios Clean Code y recomendaciones en la nomenclatura de la Programación Orientada a Objetos  

### Declaración de atributos

_saldo --> manera de declarar un atributo de campo **privado**.
Saldo --> es otra manera de escribir un atributo no privado (mayúscula al inicio)

### Namespace

**Namespace**: Es un contenedor lógico utilizado para organizar clases, interfaces, estructuras y enumeraciones relacionadas. Permite agrupar las clases en uno o varios ensamblajes.

```c#
    namespace PilaresOOP.Models;
```

+ Por lo general, sigue la jerarquía de carpetas del proyecto (Proyecto.Carpeta). En este caso, indica que el archivo pertenece a la carpeta Models dentro del proyecto PilaresOOP.  
+ **File-Scoped (Ámbito de archivo)**: Al terminar en punto y coma (;) y no usar llaves {} para envolver todo el código, se declara que todo el contenido de ese archivo .cs pertenece a ese namespace automáticamente.  

#### ¿Para qué sirve?  

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

---

### Diferencias en las expesiones de flecha 
```c#
    private double TaxRate => 0.18;
    private double TaxRate() => 0.18;
```  

La diferencia principal es que la primera es una **propiedad** y la segunda es un **método**. Aunque ambas devuelven el mismo valor usando la sintaxis de "cuerpo de expresión" (=>) o expresión lambda (expression-bodied), se usan de forma distinta:  

1. **private double TaxRate => 0.18;**  
    Es una propiedad de solo lectura.  
    Equivale a escribir:  
    ```c#
        private double TaxRate
        {
            get { return 0.18; }
        }
    ```

    + **Qué es**: Internamente es un método get.
    + **Cómo se usa**: Se accede a ella como si fuera una variable: var tax = TaxRate;
    + **Cómo se usa**: Se accede a ella como si fuera una variable: var tax = TaxRate;
    > No recibe parámetros y solo devuelve un valor.  

2. **private double TaxRate() => 0.18;**  
    Es un método.  
    + **Qué es**: Una función estándar.
    + **Cómo se usa**: Requiere paréntesis para ser invocada: var tax = TaxRate();
    + **Semántica**: Representa una acción o un cálculo, aunque en este caso sea un **valor fijo**.
    > Puede recibir parámetros, aunque aquí no.  

Es recomedable usar la forma de **propiedad de solo lectura** (sin paréntesis) para **valores constantes**.




 
