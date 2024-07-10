namespace Poker12.Core.LogicaRonda;
public class Mantener(Jugador jugador, Ronda ronda, ushort apuesta)
    : RespuestaJugadorARonda(jugador, ronda, apuesta)
{
    public override void Ejecutar()
    {
        ronda.IncrementarPozo(apuesta);
        jugador.SacarFichas(apuesta);
    }
}
