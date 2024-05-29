using Poker12.Core.Jugadas;
namespace Poker12.Core.Test.Jugadas;

public class ParejaTest
{
    private IJugada _ParejaTest;
    public ParejaTest() => _ParejaTest = new Pareja();

    [Fact]
    public void Test1()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Diez),
            new(EPalo.Picas, EValor.As),
            new(EPalo.Corazon, EValor.Cuatro),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Corazon, EValor.Tres),
        };

        var resultado = _ParejaTest.Aplicar(jugada);

        Assert.Equal(3, resultado.Valor);
    }
        [Fact]
    public void Test2()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Cuatro),
            new(EPalo.Picas, EValor.As),
            new(EPalo.Corazon, EValor.Cuatro),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Corazon, EValor.Tres),
        };

        var resultado = _ParejaTest.Aplicar(jugada);

        Assert.Equal(4, resultado.Valor);
    }
}