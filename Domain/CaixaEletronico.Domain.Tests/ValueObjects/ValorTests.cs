using CaixaEletronico.Domain.ValueObjects;

public class ValorTests
{
    [Fact]
    public void Valor_DeveLancarArgumentException_QuandoAmountForNegativo()
    {
        Assert.Throws<ArgumentException>(() => new Valor(-1));
    }

    [Fact]
    public void Valor_DeveDefinirAmount_QuandoAmountForPositivo()
    {
        var valor = new Valor(100);
        Assert.Equal(100, valor.Amount);
    }

    [Fact]
    public void Valor_ToString_DeveRetornarAmountFormatado()
    {
        var valor = new Valor(100.123m);
        var valorString = valor.ToString();
        Assert.Equal("100,12", valorString);
    }
}