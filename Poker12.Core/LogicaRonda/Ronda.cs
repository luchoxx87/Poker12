using Poker12.Core.ColeccionesCartas;

namespace Poker12.Core.LogicaRonda;
public class Ronda
{
    private static int _cantidadCartasMesa = 5;
    private static int _dadasVuelta = 3;
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
    public void DarCartas()
    {
        //TODO dar 2 cartas del maso al jugador JOUSE
        foreach (var jugador in Jugadores)
        {
                var  cartas= Mazo.Sacar(2).ToList();
                var primera=cartas[0];
                var segunda=cartas[1];
                jugador.EntregarCartas(primera, segunda);
        }
    }
    public void Jugar()
    {
        
    }

    public void DarVueltaInicial()
    {
        //TODO dar vuelta "_dadasVuelta" veces las cartas de la mesa
    }
    public void PreguntarA(Jugador jugador, CartaMesa cartaMesa)
    {

    }
    public void ProcesarRespuesta(RespuestaJugadorARonda respuesta)
        => respuesta.Ejecutar();
}