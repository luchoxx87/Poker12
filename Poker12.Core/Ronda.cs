namespace Poker12.Core.ColeccionesCartas;

public class Ronda
{
    private readonly MezcladorShuffle mezclador = new();
    private ushort ApuestaInicial { get; set; }
    private ushort ApuestaTotal { get; set; }
    private List<Jugador> Jugadores { get; set; }
    private Mazo mazo { get; set; }
    private CartaMesa cartaMesa { get; set; }

    private List<Jugador> Apostadores { get; set; }

    public Ronda(ushort ApuestaInicial, ushort ApuestaTotal, List<Jugador> Jugadores, List<Jugador> Apostadores)
        => (this.ApuestaInicial, this.ApuestaTotal, this.Jugadores, mazo, cartaMesa, this.Apostadores) = (ApuestaInicial, ApuestaTotal, Jugadores, new(mezclador.ObtenerCartas()), new(mazo.Cartas), Apostadores);
    public void RepartirCartas()
    {

    }
}