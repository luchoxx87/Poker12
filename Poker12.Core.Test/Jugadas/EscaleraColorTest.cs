using Poker12.Core.Jugadas;

namespace Poker12.Core.Test.Jugadas;

public class EscaleraColorTest
{
    private IJugada _escaleraColor;
    public EscaleraColorTest() => _escaleraColor = new EscaleraColor();

    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();

        Assert.Throws<ArgumentException>(() => _escaleraColor.Aplicar(jugada));
    }

    [Fact]
    public void GanarEscaleraColorConAs()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Cinco),
            new(EPalo.Picas, EValor.Tres),
            new(EPalo.Picas, EValor.Cuatro),
            new(EPalo.Picas, EValor.Dos),
            new(EPalo.Picas, EValor.As),
        };

        var resultado = _escaleraColor.Aplicar(jugada);

        Assert.Equal(5, resultado.Valor);
    }

    [Fact]
    public void GanarEscaleraColorSinAs()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Cinco),
            new(EPalo.Picas, EValor.Seis),
            new(EPalo.Picas, EValor.Siete),
            new(EPalo.Picas, EValor.Ocho),
            new(EPalo.Picas, EValor.Nueve),
        };

        var resultado = _escaleraColor.Aplicar(jugada);

        Assert.Equal(9, resultado.Valor);
    }

    [Fact]
    public void FallarEscaleraColor()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Dos),
            new(EPalo.Picas, EValor.Seis),
            new(EPalo.Picas, EValor.Siete),
            new(EPalo.Picas, EValor.Ocho),
            new(EPalo.Picas, EValor.Nueve),
        };

        Assert.Throws<InvalidOperationException>(() => _escaleraColor.Aplicar(jugada));
    }
}