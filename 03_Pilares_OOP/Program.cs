// See https://aka.ms/new-console-template for more information

using PilaresOOP.Models;

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

BankAccount bankAccount = new();
// Hay dos formas de ver el balance
var atmMessageConsult = bankAccount.GetAtmMessage();  // 1. Solo consulta

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(atmMessageConsult);

var atmMessage = bankAccount.Deposit(160); // 2. Haciendo un depósito

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(atmMessage);
