using CaixaEletronico.Domain.ValueObjects;

public class TipoMoedaTests
{
    [Fact]
    public void TipoMoeda_DeveLancarArgumentException_QuandoMoedaForInvalida()
    {
        Assert.Throws<ArgumentException>(() => new TipoMoeda("USD"));
    }

    [Fact]
    public void TipoMoeda_DeveDefinirMoeda_QuandoMoedaForValida()
    {
        var tipoMoeda = new TipoMoeda("BRL");
        Assert.Equal("BRL", tipoMoeda.Moeda);
    }

    [Fact]
    public void TipoMoeda_ToString_DeveRetornarMoeda()
    {
        var tipoMoeda = new TipoMoeda("BRL");
        Assert.Equal("BRL", tipoMoeda.ToString());
    }
}