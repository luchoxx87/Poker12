namespace Poker12.Core.Test;
public class CartaTest
{
    Carta _seisTrebol = new Carta(EPalo.Trebol, EValor.Seis);

    [Fact]
    public void ToStringOK()
        => Assert.Equal("Seis Trebol", _seisTrebol.ToString());
}
