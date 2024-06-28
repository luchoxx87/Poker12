namespace Poker12.Core.LogicaRonda;
public class SubirApuesta(Jugador jugador, Ronda ronda, ushort apuesta)
    : RespuestaJugadorARonda(jugador, ronda, apuesta)
{
    public override void Ejecutar()
    {
        jugador.SacarFichas(apuesta);
        ronda.ApuestaInicial = apuesta;
        ronda.IncrementarPozo(apuesta);
    }
}
