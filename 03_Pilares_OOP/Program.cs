// See https://aka.ms/new-console-template for more information

using PilaresOOP.Models;
 // ============================= Herencia ==================================== //
/* Apple redApple = new()
{
  Name = "Red Apple",
  Color = "Red",
  NumberOfSeeds = 4 
};

Apple greenApple = new()
{
  Name = "Green Apple",
  Color = "Green",
  NumberOfSeeds = 6  
};

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(redApple.DescribeMe);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(greenApple.DescribeMe); */

// ============================== Encapsulación =============================== //
/* BankAccount bankAccount = new();
// Hay dos formas de ver el balance
var atmMessageConsult = bankAccount.GetAtmMessage();  // 1. Solo consulta

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(atmMessageConsult);

var atmMessage = bankAccount.Deposit(160); // 2. Haciendo un depósito

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(atmMessage); */

// ============================== Abstracción ================================= //
Bicycle mountainBicycle = new()
{
  Company = "Good Bicy",
  Model = "Bicy x458",
  NumberOfTyres = 2
};

Car modernCar = new()
{
  Company = "Tesla",
  Model = "Car z765",
  FrontTyres = 2,
  BackTyres = 2
};

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"The vehicle named {mountainBicycle.Model} has {mountainBicycle.GetNumberOfTyres()} tyre(s)");

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"The vehicle named {modernCar.Model} has {modernCar.GetNumberOfTyres()} tyre(s)");