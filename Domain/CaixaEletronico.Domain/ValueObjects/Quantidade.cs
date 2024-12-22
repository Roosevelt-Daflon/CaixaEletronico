namespace CaixaEletronico.Domain.ValueObjects;

public class Quantidade
{
    public int Amount { get; private set; }
    public Quantidade() { }
    public Quantidade(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("A quantidade não pode ser negativa.", nameof(amount));
        
        Amount = amount;
    }
}