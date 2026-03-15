using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;

public class BankAccount
{
    public string Owner { get; set; } = ""; //Necesaria la inicialización con ""
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }

    public BankAccount()
    {
        Owner = "Fernando Ventura";
    }

}