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
    [Fact]
    public void PruebaConAs()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.As),
            new(EPalo.Picas, EValor.As),
            new(EPalo.Diamante, EValor.As),
            new(EPalo.Trebol, EValor.Dos),
            new(EPalo.Diamante, EValor.As)
        };

        var resultado = _Poker.Aplicar(jugada);

        Assert.Equal(14, resultado.Valor);
    }
    [Fact]
    public void PruebaError()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Picas, EValor.Tres),
            new(EPalo.Diamante, EValor.As),
            new(EPalo.Trebol, EValor.Dos),
            new(EPalo.Diamante, EValor.As)
        };

        var resultado = _Poker.Aplicar(jugada);

        Assert.Equal(0, resultado.Valor);
    }
}