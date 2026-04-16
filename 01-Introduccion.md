# Programación Orientada a Objetos con C#

### Qué es un objeto?
Un objeto en el **mundo real es una cosa**, como un automóvil o una persona, mientras que un **objeto en programación a menudo representa algo en el mundo real**, como un producto o una cuenta bancaria, pero también puede ser algo más abstracto.

En **C#** usamos las palabras clave **class** y **record** (principalmente) o **struct** (a veces) para definir un tipo de objeto. Puedes pensar en un tipo como un modelo o plantilla para un objeto.

> Importante aclarar que tanto **record** como **struct** son tipos de objeto aregados recientemente en las versiones 9 de C# y en adelante.

### Clases en POO
En la programación orientada a objetos, derivas objetos de clases.

Una clase es una plantilla o modelo que nos dice qué propiedades y comportamientos tendrá un objeto.

Una clase tiene:   
+ Propiedades
+ Comportamientos (métodos) que pueden llegar a afectar a las propiedades de este mismo.

> Podemos concluir que una clase en si misma no puede hacer cualquier cosa; solo se usa para crear objetos.  


### *Conceptos especializados*  
+ Un objeto es **una instancia de una clase**. En otras palabras, un objeto es una **implementación de una clase**. 

![Ejemplo de instanciación o creación de un objeto](./Resources/Instancia.png)  

+ Los términos **instanciación** y **crear un objeto** a partir de una clase son exactamente lo mismo.
+ Se dice que crear un objeto es **instanciar una clase**, es decir, implementar la clase creada.

### Configuración de trabajo

Si estamos trabajando con VS Code para este editor de código es necesario instalar la **base del Lenguaje C#** y el **Kit Dev**, ambas de la empresa Microsoft.  

Una vez en consola podemos ejecutar:
``` PowerShell
$ dotnet new console -o "Nombre_Projecto"
#Para crear un proyecto .NET de C# en este editor 
```  
Observaremos un programa principal llamado **Program.cs** en donde tendremos un "Hello, World!". *Viajamos a la ruta del proyecto recién creado* y ejecutamos:
```PowerShell
$ dotnet run
#Para ejecutar el código
```  

### Algunos pluggings recomendados:  

+ C# y Kit Dev C# de Microsoft
+ .NET Install Tool (extensión para trabajar con .NET).
+ Activitus Bar, para cambiar la vista de la barra de herramientas lateral.
+ Code Spell Checker, que sirve como un corrector ortográfico al momento de escribir cualquier palabra.
+ vscode-icons, para tener un mejor estilo de iconos en carpetas y archivos.
+ prettier para formatear el código usando ALT + SHIFT + F.




