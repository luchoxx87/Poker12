using Poker12.Core.Jugadas;

namespace Poker12.Core.Test.Jugadas;
public class FullHouseTest
{
    private IJugada _FullHouse;
    public FullHouseTest() => _FullHouse = new FullHouse();

    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();

        Assert.Throws<ArgumentException>(() => _FullHouse.Aplicar(jugada));
    }
    [Fact]
    public void PruebaConDiez()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Diez),
            new(EPalo.Trebol, EValor.Diez),
            new(EPalo.Diamante, EValor.Diez),
            new(EPalo.Trebol, EValor.As),
            new(EPalo.Corazon, EValor.As)
        };

        var resultado = _FullHouse.Aplicar(jugada);

        Assert.Equal(10, resultado.Valor);
    }
    [Fact]
    public void PruebaConFalla()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Diez),
            new(EPalo.Trebol, EValor.Diez),
            new(EPalo.Diamante, EValor.Tres),
            new(EPalo.Trebol, EValor.As),
            new(EPalo.Corazon, EValor.As)
        };

        var resultado = _FullHouse.Aplicar(jugada);

        Assert.Equal(0, resultado.Valor);
    }
    [Fact]
    public void PruebaConDos()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Cinco),
            new(EPalo.Trebol, EValor.Cinco),
            new(EPalo.Diamante, EValor.Cinco),
            new(EPalo.Trebol, EValor.Dos),
            new(EPalo.Corazon, EValor.Dos)
        };

        var resultado = _FullHouse.Aplicar(jugada);

        Assert.Equal(5, resultado.Valor);
    }
}