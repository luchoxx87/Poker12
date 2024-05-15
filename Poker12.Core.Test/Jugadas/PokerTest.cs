using Poker12.Core.Jugadas;

namespace Poker12.Core.Test.Jugadas;
public class PokerTest
{
    private IJugada _Poker;
    public PokerTest() => _Poker = new Poker();

    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();

        Assert.Throws<ArgumentException>(() => _Poker.Aplicar(jugada));
    }

    [Fact]
    public void PruebaConDiez()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Diez),
            new(EPalo.Picas, EValor.Diez),
            new(EPalo.Diamante, EValor.Diez),
            new(EPalo.Trebol, EValor.Diez),
            new(EPalo.Diamante, EValor.As)
        };

        var resultado = _Poker.Aplicar(jugada);

        Assert.Equal(10, resultado.Valor);
    }
}