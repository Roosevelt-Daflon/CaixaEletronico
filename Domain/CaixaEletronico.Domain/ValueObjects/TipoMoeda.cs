namespace CaixaEletronico.Domain.ValueObjects;

public class TipoMoeda
{
    public string Moeda { get; private set; }

    private static readonly string[] MoedasPermitidas = { "BRL" };
    public TipoMoeda() { }
    public TipoMoeda(string moeda)
    {
        if (!MoedasPermitidas.Contains(moeda))
            throw new ArgumentException("Moeda inválida.", nameof(moeda));
        
        Moeda = moeda;
    }

    public override string ToString() => Moeda.ToString();
}