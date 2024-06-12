using Poker12.Core.ColeccionesCartas;
namespace Poker12.Core.Jugadas;


public class MezcladorShuffleTest
{
    private readonly MezcladorShuffle mezclador = new();

    [Fact]
    public void ObtenerCartasTest()
    {
        var mazo = mezclador.ObtenerCartas();
        Assert.Equal(52, mazo.Count());
    }

    [Fact]
    public void MezclarCartasTest() 
    {
        var mazo = mezclador.ObtenerCartas();
        var mazoDesordenado = mezclador.MezclarCartas(mazo);

        Assert.NotEqual(mazo, mazoDesordenado);
    }
}