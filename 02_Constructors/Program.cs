// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;

BankAccount savingAccount = new ();
// Propiedades públicas, se puede acceder
savingAccount.Amount = 1200;
savingAccount.GenerarNumeroCuenta(); // Llamada al método

string message = @$"la cuenta número {savingAccount.AccountNumber} del propietario llamado {savingAccount.Owner}
tiene un ahorro total de ${savingAccount.Amount}";

// Objeto 2 constructor con parámetro
BankAccount checkingAccount = new("Luis Gustavo");
checkingAccount.Amount = 900;

string messageAuto = @$"la cuenta número {checkingAccount.AccountNumber} del propietario llamado {checkingAccount.Owner}
tiene un ahorro total de ${checkingAccount.Amount}";


Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(message);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(messageAuto);