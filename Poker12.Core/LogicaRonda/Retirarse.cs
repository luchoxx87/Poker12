namespace Poker12.Core.LogicaRonda;

public class Retirarse(Jugador jugador, Ronda ronda, ushort apuesta)
    : RespuestaJugadorARonda(jugador, ronda, apuesta)
{
    public override void Ejecutar() => jugador.Retirarse();
}