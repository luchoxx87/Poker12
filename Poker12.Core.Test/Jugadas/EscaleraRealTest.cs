using Poker12.Core.Jugadas;

namespace Poker12.Core.Test.Jugadas;

public class EscaleraRealTest
{
    private IJugada _escaleraReal;
    public EscaleraRealTest() => _escaleraReal = new EscaleraReal();

    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();

        Assert.Throws<ArgumentException>(() => _escaleraReal.Aplicar(jugada));
    }

    [Fact]
    public void GanarEscaleraRealConAs()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Trebol, EValor.As),
            new(EPalo.Trebol, EValor.Diez),
            new(EPalo.Trebol, EValor.J),
            new(EPalo.Trebol, EValor.Q),
            new(EPalo.Trebol, EValor.K)
        };

        var resultado = _escaleraReal.Aplicar(jugada);

        Assert.Equal(14, resultado.Valor);
    }

    [Fact]
    public void FallarEscaleraRealSinAs()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Trebol, EValor.Nueve),
            new(EPalo.Trebol, EValor.Diez),
            new(EPalo.Trebol, EValor.J),
            new(EPalo.Trebol, EValor.Dos),
            new(EPalo.Trebol, EValor.K)
        };
        
        Assert.Throws<InvalidOperationException>(() => _escaleraReal.Aplicar(jugada));
    }

    [Fact]
    public void FallarEscaleraReal()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Trebol, EValor.Tres),
            new(EPalo.Trebol, EValor.Cuatro),
            new(EPalo.Trebol, EValor.Cinco),
            new(EPalo.Trebol, EValor.Seis),
            new(EPalo.Trebol, EValor.Siete)
        };
        
        Assert.Throws<InvalidOperationException>(() => _escaleraReal.Aplicar(jugada));
    }
}