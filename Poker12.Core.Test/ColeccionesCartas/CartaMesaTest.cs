using Poker12.Core.ColeccionesCartas;
namespace Poker12.Core.Test.ColeccionesCartas;

public class CartaMesaTest
{
    private readonly NoMezcla nomezcla = new();
    [Fact]
    public void Test1()
    {
        Mazo mazo = new(nomezcla.ObtenerCartas());
        CartaMesa cartaMesa = new(mazo.Cartas);
        nomezcla.MezclarCartas(mazo.Cartas);
        cartaMesa.DarVuelta();
        cartaMesa.DarVuelta();
    Assert.Equal(2, cartaMesa.BocaArriba.Count);
    }
}