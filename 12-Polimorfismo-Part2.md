# Polimorfismo en tiempo de compilación y en tiempo de ejecución

### 1. Polimorfismo en tiempo de compilación (Compile-time polymorphism)

También llamado:

+ Polimorfismo estático
+ Overload
+ Sobrecarga de métodos

**Qué significa?**

El **compilador decide antes** de ejecutar el programa qué método usar.

Esto ocurre cuando usamos:

+ Sobrecarga de métodos (overload)
+ Sobrecarga de operadores
+ Constructores sobrecargados  

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
    }
```
Uso:
```c#
    Calculadora c = new Calculadora();

    c.Sumar(2, 3);     
    c.Sumar(2.5, 3.1);
```

El compilador sabe cuál usar porque:

+ Los parámetros son distintos

✔ Se decide en compilación  
✔ No necesita herencia  
✔ No usa virtual  

### 2. Polimorfismo en tiempo de ejecución (Run-time polymorphism) 

También llamado:

+ Polimorfismo dinámico
+ Override
+ Virtual / abstract / interface  

**Qué significa?**

El método se decide cuando el programa está corriendo, no antes.

Se usa cuando hay:

+ Herencia
+ virtual
+ override
+ abstract
+ interface (herencia de interfaces)  

Ejemplo:
```c#
    class Animal
    {
        public virtual void Sonido()
        {
            Console.WriteLine("Sonido");
        }
    }
```
Clases derivadas:
```c#
    class Perro : Animal
    {
        public override void Sonido()
        {
            Console.WriteLine("Guau");
        }
    }
```
```c#
class Gato : Animal
    {
        public override void Sonido()
        {
            Console.WriteLine("Miau");
        }
    }
```
Uso: 
```c#
    Animal a;

    a = new Perro();
    a.Sonido();

    a = new Gato();
    a.Sonido();
```  

El compilador solo sabe que es Animal.

Pero en ejecución decide:

+ Perro → Guau
+ Gato → Miau

✔ Se decide en ejecución  
✔ Usa herencia  
✔ Usa virtual / override  

## Forma fácil de recordarlo

| Caso | Tipo |
|------|--------|
| Mismo método, distintos parámetros | Compilación |
| Clase padre → hijo con override | Ejecución |
| Interface | Ejecución |
| Abstract | Ejecución |