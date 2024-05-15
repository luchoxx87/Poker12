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
    public void FallaPorJugadaSinCincoCartas()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Dos),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Corazon, EValor.Dos),
        };

        Assert.Throws<InvalidOperationException>(() => escalera.Aplicar(jugada));
    }

    [Fact]
    public void CorrectoEscaleraSinAS()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Trebol, EValor.Cuatro),
            new(EPalo.Picas, EValor.Seis),
            new(EPalo.Corazon, EValor.Cinco),
            new(EPalo.Diamante, EValor.Dos),
            new(EPalo.Corazon, EValor.Tres),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(6, resultado.Valor);
    }

    [Fact]
    public void CorrectoEscaleraConASComoUno()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Cinco),
            new(EPalo.Corazon, EValor.Dos),
            new(EPalo.Corazon, EValor.Cuatro),
            new(EPalo.Trebol, EValor.Tres),
            new(EPalo.Diamante, EValor.As),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(5, resultado.Valor);
    }

    [Fact]
    public void CorrectoEscaleraConASComoCatorce()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Diez),
            new(EPalo.Corazon, EValor.J),
            new(EPalo.Diamante, EValor.As),
            new(EPalo.Trebol, EValor.Q),
            new(EPalo.Corazon, EValor.K),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(14, resultado.Valor);
    }
    [Fact]
    public void CorrectoEscaleraParte2()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Nueve),
            new(EPalo.Diamante, EValor.Diez),
            new(EPalo.Trebol, EValor.Q),
            new(EPalo.Corazon, EValor.J),
            new(EPalo.Picas, EValor.K),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(13, resultado.Valor);
    }

    [Fact]
    public void IncorrectoEscaleraParte2()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Nueve),
            new(EPalo.Diamante, EValor.Diez),
            new(EPalo.Trebol, EValor.Q),
            new(EPalo.Corazon, EValor.K),
            new(EPalo.Picas, EValor.As),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(0, resultado.Valor);
    }

    [Fact]
    public void IncorrectoEscalera()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Nueve),
            new(EPalo.Corazon, EValor.J),
            new(EPalo.Diamante, EValor.As),
            new(EPalo.Trebol, EValor.Q),
            new(EPalo.Corazon, EValor.K),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(0, resultado.Valor);
    }
    [Fact]
    public void VariosAS()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Trebol, EValor.As),
            new(EPalo.Picas, EValor.As),
            new(EPalo.Corazon, EValor.As),
            new(EPalo.Diamante, EValor.K),
            new(EPalo.Corazon, EValor.Tres),
        };
        var resultado = escalera.Aplicar(jugada);

        Assert.Equal(0, resultado.Valor);
    }
}