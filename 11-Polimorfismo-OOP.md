# Polimorfismo

La palabra polimorfismo siginifica muchas formas.
En OOP, el polimorfismo permite que una misma acción tenga diferentes comportamientos según el objeto.  
Significa que un mismo método puede comportarse de diferentes maneras dependiendo del objeto que lo use.

### **Tipos de polimorfismo**

En C#, hay dos tipos de polimorfismo: **polimorfismo estático** y **polimorfismo dinámico**.  

+ El polimorfismo estático sucede en **tiempo de compilación**.
+ El polimorfismo dinámico sucede en **tiempo de ejecución**.  

#### En C# el polimorfismo se usa principalmente con:

+ virtual
+ override
+ abstract
+ interface
+ sobrecarga de métodos (overload)

## Recursos del polimorfismo

### 1. Sobrecarga de métodos (Overload)  

La sobrecarga (overload) ocurre cuando un método **tiene el mismo nombre pero diferentes parámetros**.  

El compilador decide cuál usar según los argumentos.  
También se llama polimorfismo en tiempo de compilación. 
Ejemplo:  
```c#
    class Calculadora
    {
        public int Sumar(int a, int b)
        {
            return a + b;
        }

        public double Sumar(double a, double b)
        {
            return a + b;
        }

        public int Sumar(int a, int b, int c)
        {
            return a + b + c;
        }
    }
```  
Uso: 
```c#
    Calculadora c = new Calculadora();

    c.Sumar(2,3);
    c.Sumar(2.5,3.1);
    c.Sumar(1,2,3);
```  
+ Mismo nombre
+ Diferentes parámetros
+ Diferente comportamiento  

**Cuándo se usa?**  
Se usa cuando:
+ El método hace lo mismo, pero, con diferentes datos.  
Ejemplos reales:  
+ Print(string)
+ Print(int)
+ Print(double)
+ Sumar(int,int)
+ Sumar(double,double)

    + Muy usado en librerías
    + Muy usado en utilidades
    + Muy usado en constructores

### 2. Virtual y Override  
**Virtual** permite que un método de una clase base pueda ser **redefinido** en una **clase hija**.  
Se usa con **herencia**.  

Ejemplo:
```c#  
    class Animal
    {
        public virtual void HacerSonido()
        {
            Console.WriteLine("Sonido");
        }
    }
```
Clases hijas:
```c#
    class Perro : Animal
    {
        public override void HacerSonido()
        {
            Console.WriteLine("Guau");
        }
    }
```
```c#
    class Gato : Animal
    {
        public override void HacerSonido()
        {
            Console.WriteLine("Miau");
        }
    }
```  
Uso: 
```c#
    Animal a1 = new Perro();
    Animal a2 = new Gato();

    a1.HacerSonido();
    a2.HacerSonido();
```  
Resultado:
```c#
    Guau
    Miau
```  
+ Mismo método
+ Diferente comportamiento
+ Polimorfismo real  

**Cuándo se usa virtual  
Se usa cuando:

+ Hay herencia
+ La clase base define comportamiento general
+ Las clases hijas lo modifican

Ejemplos:

+ Animal → Perro, Gato, Ave
+ Figura → Cuadrado, Círculo
+ Empleado → Gerente, Programador

### 3. Interfaces  
Una **interface** es un contrato.  
Dice:  
> Toda clase que use esta interface debe implementar estos métodos.  

No tiene código, solo definición.  
Ejemplo:  
```c#
    interface IVehiculo
    {
        void Mover();
    }
```  
Clases que implementan la interface:
```c#  
    class Auto : IVehiculo
    {
        public void Mover()
        {
            Console.WriteLine("El auto avanza");
        }
    }
```
```c#
    class Avion : IVehiculo
    {
        public void Mover()
        {
            Console.WriteLine("El avión vuela");
        }
    }
```  
Uso:
```c#
    IVehiculo v1 = new Auto();
    IVehiculo v2 = new Avion();

    v1.Mover();
    v2.Mover();
```  

**Cuándo se usan interfaces**  
Se usan cuando:

+ Diferentes clases deben hacer lo mismo
+ No comparten herencia
+ Se quiere obligar a implementar métodos

Ejemplos reales:

+ IDisposable
+ IComparable
+ IEnumerable
+ ILogger
+ IVehiculo 

> IMPORTANTE: **interface** no usa **herencia de clases**, como si lo hace **virtual**, y es que, no es lo mismo la herencia de una clase padre a una clase hija que recibe código (propiedades y métodos); recuerda que una interfaz no tiene código, es solo una definición. 
Por lo tanto, cuando aplicamos **herencia de interfaces** no dices que una clase es su padre, sino **que la clase cumple un contrato**.  

Ahora bien un dato extra:

**Las interfaces pueden heredar de otras interfaces**.  
```c#
    interface IAnimal
    {
        void Comer();
    }

    interface IMascota : IAnimal
    {
        void Jugar();
    }
```  
Ahora cualquier clase que implemente **IMascota**
debe implementar **TODO**.  
```c#
    class Perro : IMascota
    {
        public void Comer()
        {
        }

        public void Jugar()
        {
        }
    }
```  
+ Aquí sí hay herencia
+ Pero entre interfaces
+ No entre clases 

## EJEMPLOS DE POLIMORFISMO  

### 1. Polimorfismo con override (el más importante)  

```c#
    class Animal
    {
        public virtual void HacerSonido()
        {
            Console.WriteLine("El animal hace sonido");
        }
    }
```
Clases derivada
```c#
    class Perro : Animal
    {
        public override void HacerSonido()
        {
            Console.WriteLine("Guau");
        }
    }
```
```c#
    class Gato : Animal
    {
        public override void HacerSonido()
        {
            Console.WriteLine("Miau");
        }
    }
```
Uso:
```c#
    Animal a1 = new Perro();
    Animal a2 = new Gato();

    a1.HacerSonido();
    a2.HacerSonido();
```
Salida:
```c#
    Guau
    Miau
```
+ Mismo método
+ Diferente comportamiento
+ POLIMORFISMO  

### 2. Polimorfismo por sobrecarga (Overload) o sobrecarga de métodos 
Mismo nombre, diferentes parámetros.  

```c#
    class Calculadora
    {
        public int Sumar(int a, int b)
        {
            return a + b;
        }

        public double Sumar(double a, double b)
        {
            return a + b;
        }
    }
```  
Uso:
```c#
    Sumar(2,3);
    Sumar(2.5,3.7);
```  
+ Mismo método
+ Diferentes tipos
+ Polimorfismo  

### 3. Polimorfismo con clases abstractas
```c#
    abstract class Figura
    {
        public abstract double Area();
    } 
```
Clase derivada (es obligatorio implementar el método abstracto con la palabra **override**):
```c#
    class Cuadrado : Figura
    {
        public override double Area()
        {
            return 4 * 4;
        }
    }
```  
Cada figura calcula el área diferente.  

### 4. Polimorfismo con interfaces  

```c#
    interface IVehiculo
    {
        void Mover();
    }
```  
Clases derivadas de la interface (herencia de interface):
```c#
    class Auto : IVehiculo
    {
        public void Mover()
        {
            Console.WriteLine("El auto se mueve");
        }
    }
```  
```c#
    class Avion : IVehiculo
    {
        public void Mover()
        {
            Console.WriteLine("El avión vuela");
        }
    }
```

### Resumen sencillo  

| Concepto     | Significado                        |
| ------------ | ---------------------------------- |
| Polimorfismo | Un método con muchas formas        |
| override     | Cambiar comportamiento             |
| overload     | Mismo método, distintos parámetros |
| virtual      | Permite modificar                  |
| abstract     | Obliga a modificar                 |
| interface    | Contrato que se debe cumplir       |



### Definición corta 

El polimorfismo es la capacidad de la programación orientada a objetos de permitir que un mismo método tenga diferentes comportamientos dependiendo del objeto que lo implemente.
  



