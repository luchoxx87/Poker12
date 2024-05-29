using Microsoft.VisualBasic;
using Poker12.Core.Jugadas;
namespace Poker12.Core.Test.Jugadas;
public class DobleParTest
{
    private IJugada doblePar;
    public DobleParTest() => doblePar = new DoblePar();
    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();
        Assert.Throws<ArgumentException>(() => doblePar.Aplicar(jugada));
    }
    [Fact]
    public void ProbandoDobleParConAs()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Trebol, EValor.As),
            new(EPalo.Diamante, EValor.As),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Diamante, EValor.Tres),
            new(EPalo.Corazon, EValor.Cinco),
        };
        var resultado = doblePar.Aplicar(jugada);
        Assert.Equal(143, resultado.Valor); 
    }
    [Fact]
    public void ProbandoDoblePar()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Trebol, EValor.Cuatro),
            new(EPalo.Diamante, EValor.Cuatro),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Diamante, EValor.Tres),
            new(EPalo.Corazon, EValor.Cinco),
        };
        var resultado = doblePar.Aplicar(jugada);
        Assert.Equal(34, resultado.Valor); 
    }
    [Fact]
    public void FormaIncorrectaDePruebaDoblePar()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Trebol, EValor.As),
            new(EPalo.Corazon, EValor.K),
            new(EPalo.Corazon, EValor.Cinco),
            new(EPalo.Corazon, EValor.Ocho),
            new(EPalo.Corazon, EValor.Siete),
        };
        Assert.Throws<InvalidOperationException>(() => doblePar.Aplicar(jugada));
    }
}
