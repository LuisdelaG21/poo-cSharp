using System.IO.Pipelines;

namespace PilaresOOP.Models;
public class BankAccount
{
    // Atributos privados, solo accesibles desde la misma clase
    private double AccountBalance { get; set; } // saldo de la cuenta
    private double TaxRate => 0.18; // tasa de impuesto constante; propiedad de solo lectura

    public string Deposit(double amount)
    {
        AccountBalance += amount;
        return GetAtmMessage();
    }

    public double GetAccountBalance()
    {
        double balanceAfterTax = GetBalanceAfterTax();
        return balanceAfterTax;   
    }

    private double GetBalanceAfterTax() => AccountBalance * TaxRate;

    // Método para impresión en consola
    public string GetAtmMessage()
    {
        return $"Your current account balance is {GetAccountBalance()}";
    }
}