namespace PilaresOOP.Models;

// Implementar una clase abstracta funciona igual que una herencia, agregando que, 
// debemos hacer una reescritura(override) de las propiedades y métodos de esa clase
public class Bicycle : Vehicle 
{
    public string Company { get; set; } = "";
    public string Model { get; set; } = "";
    public int NumberOfTyres { get; set; }

    public override int GetNumberOfTyres() // Reescritura o sobreescritura del método de la clase abstracta Vehicle{}
    {
        return NumberOfTyres;
    }   
}