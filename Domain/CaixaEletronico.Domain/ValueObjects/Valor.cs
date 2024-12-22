namespace CaixaEletronico.Domain.ValueObjects;

public class Valor
{
    public decimal Amount { get; private set; }
    
    public Valor() { }
    
    public Valor(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("O valor não pode ser negativo.", nameof(amount));
        
        Amount = amount;
    }

    public override string ToString() => Amount.ToString("F2"); 
}