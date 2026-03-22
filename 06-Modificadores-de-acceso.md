# Modificadores de acceso en C#  

Los modificadores de acceso son la base del encapsulamiento en POO. Controlan qué partes del código pueden ver y usar los miembros de una clase.

## 1. public - Acceso total  

Cualquier código, en cualquier ensamblado, puede acceder al miembro.

```c#
public class Persona
{
    public string Nombre { get; set; } // Accesible desde cualquier lugar
}

// Desde otro proyecto o clase:
var p = new Persona();
p.Nombre = "Ana"; // ✅ Permitido
```  
> **Cuándo usarlo**: en la API que quieres exponer al mundo exterior: métodos de servicio, propiedades de modelos de datos, clases de utilidad.  

## 2. private - Acceso mínimo

Solo accesible **dentro de la misma clase**. Es el nivel más restrictivo y el predeterminado para miembros si no se especifica nada.

```c#
public class CuentaBancaria
{
    private decimal _saldo; // Solo esta clase puede tocarlo

    public void Depositar(decimal monto)
    {
        if (monto > 0)
            _saldo += monto; // ✅ Acceso interno válido
    }
}

// Desde afuera:
var cuenta = new CuentaBancaria();
cuenta._saldo = 1000; // ❌ Error de compilación
```  

> **Cuándo usarlo**: estado interno de la clase, lógica de implementación, campos de respaldo de propiedades.  

## 3. protected - Acceso para la jerarquía (clases derivadas)

Accesible dentro de la clase y en todas sus clases derivadas, sin importar el ensamblado (puede ser desde un proyecto externo).  

```c#
public class Animal
{
    protected string Sonido; // Solo Animal y sus hijos

    public void HacerSonido() => Console.WriteLine(Sonido);
}

public class Perro : Animal
{
    public Perro()
    {
        Sonido = "Guau"; // ✅ Permitido por herencia
    }
}

var a = new Animal();
a.Sonido = "..."; // ❌ Error, no es subclase ni la clase misma
```  
> **Cuándo usarlo**: cuando diseñas clases base que serán heredadas y necesitas compartir implementación sin exponerla públicamente.  

## 4. internal - Acceso por ensambaldo (en el mismo proyecto)  

Accesible desde cualquier clase dentro del mismo proyecto/ensamblado (.dll o .exe), pero invisible desde proyectos externos.  

```c#
// En el proyecto "MiBiblioteca"
internal class ConectorBaseDatos
{
    internal string CadenaConexion { get; set; }
}

// En el proyecto "MiApp" (referencia a MiBiblioteca):
var conector = new ConectorBaseDatos(); // ❌ No existe para este proyecto
```  
> **Cuándo usarlo**: clases de infraestructura interna de una librería que no deben ser parte de su API pública.  

## Combinación: protected internal y private protected

C# también ofrece dos modificadores compuestos:

| Modificador       | Acceso permitido                               |  
|-------------------|------------------------------------------------|  
| protected internal| Subclases o cualquier clase del mismo proyecto |
| private protected | Solo subclases dentro del mismo ensamblado     |  

## Diagrama  

![Modificadores de acceso](./Resources/modificadores_tabla_comparativa.png)  

![Condiciones modificadores](./Resources/modificadores_condiciones.png)  

**Más restrictivos** → **más abiertos**:
private → private protected → protected → internal → protected internal → public.  

Los dos casos que más confunden son los combinados: **protected internal** usa lógica OR (mismo ensamblado o subclase), mientras que **private protected** usa lógica AND (mismo ensamblado y subclase). Ese detalle marca una diferencia enorme en diseños de librerías.  

### Aclaraciones:  

Subclase misma DLL — la clase que hereda (**ClaseB : ClaseA**) está compilada en el **mismo proyecto** que la clase base. Por ejemplo, ClaseA y ClaseB viven ambas en MiLibreria.dll.  

Subclase otra DLL — la clase derivada está en un **proyecto distinto** que referencia al primero. Por ejemplo, **ClaseA** está en MiLibreria.dll y **ClaseB : ClaseA** está en MiApp.exe o OtraLibreria.dll.  

La distinción importa porque modificadores como **protected** permiten lo primero pero restringen lo segundo — y private **protected** directamente bloquea el acceso si la subclase está en otra DLL, aunque herede correctamente.  

> En la práctica, "misma DLL" = mismo proyecto de Visual Studio / mismo < Project > en el .sln. "Otra DLL" = proyecto separado que agrega una referencia (< ProjectReference > o NuGet).

## Impacto en los pilares de POO  

- **Encapsulamiento**: **private** protege el estado interno. Expones solo lo necesario con **public**, ocultando la implementación detrás de métodos y propiedades.  

- **Herencia**: **protected** permite que las clases hijas reutilicen y extiendan comportamiento sin romper la encapsulación frente al resto del sistema.  

- **Abstracción**: La combinación de **public** para la interfaz e **internal**/**private** para los detalles permite diseñar APIs limpias donde el consumidor no necesita conocer los mecanismos internos.  

>> **Regla de oro**: comienza siempre con **private** y abre el acceso solo cuando sea necesario. Cuanto más restringido es el acceso, más fácil es refactorizar sin romper código externo.  

## **Relación con los objetos** 

Cuando creas un objeto de una clase derivada, hereda todo de la clase padre — incluyendo los miembros **private**. Lo que cambia es desde dónde puedes accederlos.  

```c#
public class Animal
{
    private string   _id     = "A001";   // Solo Animal lo ve
    protected string Sonido  = "...";    // Animal y sus hijos
    public string    Nombre  { get; set; }
}

public class Perro : Animal  //Herencia
{
    public void Info()
    {
        Console.WriteLine(_id);    // ❌ Error: _id es private de Animal
        Console.WriteLine(Sonido); // ✅ protected, soy hijo de Animal
        Console.WriteLine(Nombre); // ✅ public, todos pueden
    }
}
```  
```c#
// Código externo (otra clase/archivo.cs cualquiera)
var perro = new Perro();

perro.Nombre = "Rex";    // ✅ public
perro.Sonido = "Guau";   // ❌ protected, no eres subclase ni la clase misma
perro._id    = "B002";   // ❌ private, absolutamente nadie externo
```  

### ¿Cómo se modifica entonces un atributo private?

A través de métodos o propiedades **public** que la clase expone deliberadamente — esto es el encapsulamiento en acción:

```c#
public class Animal
{
    private int _edad;

    // La clase controla cómo se modifica _edad
    public void SetEdad(int edad)
    {
        if (edad >= 0 && edad <= 50)
            _edad = edad; // ✅ válido desde adentro
    }

    public int GetEdad => _edad;
}

var a = new Animal();
a._edad = -5;      // ❌ imposible
a.SetEdad(-5);     // ✅ compilado, pero el if lo rechaza
a.SetEdad(3);      // ✅ _edad = 3
```  

El atributo **private** sí existe en el objeto, solo que la clase decide cómo y cuándo puede ser modificado desde afuera.  

## Dato interesante 

De repente encotrarás que la declaración de un método se hace de la siguiente manera:
```c#
public int GetEdad => _edad;
```  
Y no de la forma tradicional:
```c#
public int GetEdad()
{
    return _edad;
}
```  

Bueno, para los dos casos, **no hay ninguna diferencia funcional**. El símbolo => en este contexto se llama expression-bodied member y es simplemente una sintaxis abreviada que introdujo C# 6 para **métodos que solo tienen una expresión como cuerpo**. Es pura preferencia de escritura.

- **¿Cuándo tiene sentido usarla?**  
Cuando el método es tan simple que las llaves y el **return** son más ruido que código útil. Compara la legibilidad:   

   ```c#
    // Sin abreviar — mucho ceremonial para tan poco
    public string GetNombreCompleto()
    {
        return _nombre + " " + _apellido;
    }

    public bool EsMayorDeEdad()
    {
        return _edad >= 18;
    }

    public void Saludar()
    {
        Console.WriteLine("Hola, soy " + _nombre);
    }

    // Con expression-bodied — más limpio
    public string GetNombreCompleto => _nombre + " " + _apellido;
    public bool EsMayorDeEdad      => _edad >= 18;
    public void Saludar             => Console.WriteLine("Hola, soy " + _nombre);
   ```  

   Otro ejemplo usando propiedades y el recurso **interpolación de cadenas**:  

   ```c#
    // Propiedad de solo lectura tradicional
    public string Descripcion
    {
        get { return $"{_nombre} tiene {_edad} años"; }
    }

    // Abreviada
    public string Descripcion => $"{_nombre} tiene {_edad} años";
   ```

- **Cuándo no usarla**  
En cuanto el método necesita más de una línea de lógica, vuelves a la forma tradicional: 

   ```c#
   // Aquí ya no aplica la sintaxis corta
    public void SetEdad(int edad)
    {
        if (edad < 0) throw new ArgumentException("Edad inválida");
        if (edad > 150) throw new ArgumentException("Edad irreal");
        _edad = edad;
    }
   ```

> En resumen: **=>** en métodos es azúcar sintáctica — hace el código más legible cuando la lógica es simple, pero no cambia absolutamente nada en el comportamiento del programa.










