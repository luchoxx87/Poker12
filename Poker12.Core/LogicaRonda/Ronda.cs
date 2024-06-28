using Poker12.Core.ColeccionesCartas;

namespace Poker12.Core.LogicaRonda;
public class Ronda
{
    private static int _cantidadCartasMesa = 5;
    public ushort ApuestaInicial { get; set; }
    public ushort ApuestaTotal { get; private set; } = 0;
    private List<Jugador> Jugadores { get; set; }
    private Mazo Mazo { get; set; }
    private CartaMesa CartaMesa { get; set; }
    public Ronda(ushort ApuestaInicial, List<Jugador> Jugadores, Mazo mazo)
    {
        (this.ApuestaInicial, this.Jugadores, Mazo)
            = (ApuestaInicial, Jugadores, mazo);
        CartaMesa = new(mazo.Sacar(_cantidadCartasMesa));
    }
    public void IncrementarPozo(ushort fichas) => ApuestaTotal += fichas;
}