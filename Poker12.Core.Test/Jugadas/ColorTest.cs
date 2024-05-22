using Poker12.Core.Jugadas;
namespace Poker12.Core.Test.Jugadas;

public class ColorTest
{
    private IJugada color;
    public ColorTest() => color = new Color();

    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();

        Assert.Throws<ArgumentException>(() => color.Aplicar(jugada));
    }
    [Fact]
    public void CorrectoPruebaColorConAs()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Diez),
            new(EPalo.Corazon, EValor.As),
            new(EPalo.Corazon, EValor.Cinco),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Corazon, EValor.Dos),
        };
        var resultado = color.Aplicar(jugada);

        Assert.Equal(14, resultado.Valor);
    }

    [Fact]
    public void CorrectoPruebaColorSinAs()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Diez),
            new(EPalo.Corazon, EValor.K),
            new(EPalo.Corazon, EValor.Cinco),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Corazon, EValor.Dos),
        };
        var resultado = color.Aplicar(jugada);

        Assert.Equal(13, resultado.Valor); // Credito a axel martinez por el numero
    }

    [Fact]
    public void IncorrectoPruebaColor()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Diamante, EValor.Diez),
            new(EPalo.Corazon, EValor.As),
            new(EPalo.Corazon, EValor.Cinco),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Corazon, EValor.Dos),
        };
        var resultado = color.Aplicar(jugada);

        Assert.Equal(0, resultado.Valor);
    }
}