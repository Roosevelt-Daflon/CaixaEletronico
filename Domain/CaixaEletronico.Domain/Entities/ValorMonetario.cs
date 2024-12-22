using CaixaEletronico.Domain.ValueObjects;

namespace CaixaEletronico.Domain.Entities;

public class ValorMonetario
{
    public ValorMonetario()
    {
        
    }
    
    public ValorMonetario(Valor valor, Quantidade quantidade, TipoMoeda tipoMoeda)
    {
        this.valor = valor;
        Quantidade = quantidade;
        TipoMoeda = tipoMoeda;
    }
    
    public int Id { get; set; }
    public Valor valor { get; set; }
    public Quantidade Quantidade  { get; set; }
    public TipoMoeda TipoMoeda { get; set; }
}