using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;

class BankAccount
{
    private string _owner; // Por defecto se entiende que un valor de campo privado
    public string Owner => _owner; // Propiedad de solo lectura, equivalente a: public string Owner { get { return _owner; } }
                                   // No permite setear, devuelve directamente el valor del campo privado.
    private int _accountNumber;
    public int AccountNumber => _accountNumber;
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }

    public BankAccount()
    {
        _owner = "Fernando Ventura";
        IsActive = true;
    }
    // Crearemos un constructor más dinámico
    public BankAccount(string Owner)
    { // El valor del propietario y el número de cuenta se inicializan aquí
        GenerarNumeroCuenta();
        _owner = Owner;
        IsActive = true;
    }

    public void GenerarNumeroCuenta()
    {
        var rnd = new Random();
        _accountNumber = rnd.Next(); // Posible ya que _accountNumber esta dentro de la clase
    }
}