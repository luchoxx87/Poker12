namespace Poker12.Core.ColeccionesCartas;

public class Mazo(IEnumerable<Carta> cartas) : ConPilaCartas(cartas)
{
    public IEnumerable<Carta> Cartas => pila;
    public Carta Sacar() => pila.Pop();
    public IEnumerable<Carta> Sacar(int cantidad)
    {
        var cartas = new Carta[cantidad];
        for (int i = 0; i < cantidad; cartas[i++] = Sacar()) ;
        return cartas;
    }
}