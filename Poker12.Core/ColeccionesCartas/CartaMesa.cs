namespace Poker12.Core.ColeccionesCartas;
public class CartaMesa(IEnumerable<Carta> cartas) : ConPilaCartas(cartas)
{
    public List<Carta> BocaArriba { get; set; } = [];
    public Carta DarVuelta()
    {
        var cartavolteado = pila.Pop();
        BocaArriba.Add(cartavolteado);
        return cartavolteado;
    }
}