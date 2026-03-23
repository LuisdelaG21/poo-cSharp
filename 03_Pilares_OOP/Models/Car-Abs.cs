using System.Reflection.Metadata.Ecma335;

namespace PilaresOOP.Models;

public class Car : Vehicle
{
    public string Company { get; set; } = "";
    public string Model { get; set; } = "";
    public int FrontTyres { get; set; }
    public int BackTyres { get; set; }

    public override int GetNumberOfTyres() // Otra implementación del método abstracto de la clase Vehicle{}
    {
        return FrontTyres + BackTyres;
    }
}