namespace Poker12.Core.LogicaRonda;

public class ApostarTodo(Jugador jugador, Ronda ronda, ushort apuesta)
    : RespuestaJugadorARonda(jugador, ronda, apuesta)
{
    public override void Ejecutar()
    {
        ronda.IncrementarPozo(jugador.Fichas);
        jugador.JugarResto();
    }
}