namespace Poker12.Core.ColeccionesCartas;

public class Mazo(IEnumerable<Carta> cartas) : ConPilaCartas(cartas)
{
    public IEnumerable<Carta> Cartas => pila;
    public Carta Sacar() => pila.Pop();
}