using CaixaEletronico.Domain.ValueObjects;
using Xunit;

public class QuantidadeTests
{
    [Fact]
    public void Quantidade_DeveLancarArgumentException_QuandoAmountForNegativo()
    {
        Assert.Throws<ArgumentException>(() => new Quantidade(-1));
    }

    [Fact]
    public void Quantidade_DeveDefinirAmount_QuandoAmountForPositivo()
    {
        var quantidade = new Quantidade(10);
        Assert.Equal(10, quantidade.Amount);
    }
}