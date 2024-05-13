using Poker12.Core.Jugadas;
namespace Poker12.Core.Test.Jugadas;

public class EscaleraTest
{
    private IJugada escalera;
    public EscaleraTest() => escalera = new Escalera();

    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();

        Assert.Throws<ArgumentException>(() => escalera.Aplicar(jugada));
    }

    [Fact]
    public void CorrectoEscaleraSinAS()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Diamante, EValor.Dos),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Trebol, EValor.Cuatro),
            new(EPalo.Corazon, EValor.Cinco),
            new(EPalo.Picas, EValor.Seis),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(6, resultado.Valor);
    }

    [Fact]
    public void CorrectoEscaleraConAS()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Diamante, EValor.As),
            new(EPalo.Corazon, EValor.Dos),
            new(EPalo.Trebol, EValor.Tres),
            new(EPalo.Corazon, EValor.Cuatro),
            new(EPalo.Picas, EValor.Cinco),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(5, resultado.Valor);
    }

    [Fact]
    public void CorrectoEscaleraConASNumeroGrande()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.J),
            new(EPalo.Trebol, EValor.Q),
            new(EPalo.Corazon, EValor.K),
            new(EPalo.Picas, EValor.Diez),
            new(EPalo.Diamante, EValor.As),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(14, resultado.Valor);
    }
}