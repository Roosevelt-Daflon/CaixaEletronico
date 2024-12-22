using CaixaEletronico.Domain.Entities;
using CaixaEletronico.Domain.ValueObjects;
using Xunit;

public class ValoreMonetarioTests
{
    [Fact]
    public void ValoreMonetario_DeveDefinirPropriedadesCorretamente()
    {
        var valor = new Valor(100);
        var quantidade = new Quantidade(10);
        var tipoMoeda = new TipoMoeda("BRL");

        var valoreMonetario = new ValorMonetario
        {
            Id = 1,
            valor = valor,
            Quantidade = quantidade,
            TipoMoeda = tipoMoeda
        };

        Assert.Equal(1, valoreMonetario.Id);
        Assert.Equal(valor, valoreMonetario.valor);
        Assert.Equal(quantidade, valoreMonetario.Quantidade);
        Assert.Equal(tipoMoeda, valoreMonetario.TipoMoeda);
    }
}