using Poker12.Core.ColeccionesCartas;

namespace Poker12.Core.LogicaRonda;
public class Ronda
{
    public ushort ApuestaInicial { get; set; }
    private ushort ApuestaTotal { get; set; } = 0;
    private List<Jugador> Jugadores { get; set; }
    private Mazo Mazo { get; set; }
    private CartaMesa CartaMesa { get; set; }
    public Ronda(ushort ApuestaInicial, List<Jugador> Jugadores, Mazo mazo)
    {
        (this.ApuestaInicial, this.Jugadores, Mazo)
            = (ApuestaInicial, Jugadores, mazo);
    }
    
}