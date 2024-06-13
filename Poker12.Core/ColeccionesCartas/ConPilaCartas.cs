namespace Poker12.Core.ColeccionesCartas;
public abstract class ConPilaCartas(IEnumerable<Carta> cartas)
{
    protected Stack<Carta> pila = new(cartas);
}
