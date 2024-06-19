namespace Poker12.Core.LogicaRonda;
public abstract class RespuestaJugadorARonda(Jugador jugador, Ronda ronda, ushort apuesta)
{
    protected readonly Jugador jugador = jugador;
    protected readonly Ronda ronda = ronda;
    protected readonly ushort apuesta = apuesta;
    /// <summary>
    /// Este método ejecuta la respuesta seleccionada por el jugador
    /// </summary>
    public abstract void Ejecutar();
}
