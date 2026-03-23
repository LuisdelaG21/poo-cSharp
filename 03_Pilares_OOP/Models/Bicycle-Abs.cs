namespace PilaresOOP.Models;

// Implementar una clase abstracta funciona igual que una herencia, agregando que, 
// debemos hacer una reescritura(override) de las propiedades y métodos de esa clase
public class Bicycle : Vehicle 
{
    public string Company { get; set; } = "";
    public string Model { get; set; } = "";
    public int NumberOfTyres { get; set; }

    //Ejemplo polimorfismo dinámico (en tiempo de ejecución)
    public override int GetNumberOfTyres() //  Sobreescritura  del método de la clase abstracta Vehicle{}, override = anular.
    {
        return NumberOfTyres;
    }   
}