using Poker12.Core.ColeccionesCartas;

namespace Poker12.Core.LogicaRonda.Test;
public abstract class RespuestaBase
{
    protected Ronda ronda;
    protected Jugador Tomy;
    protected ushort ApuestaInicial = 500;
    protected readonly IMezclador Mezclador = new NoMezcla();
    public RespuestaBase()
    {
        Tomy = new Jugador("Tomy", 100);
        var mazo = new Mazo(Mezclador.ObtenerCartas());
        ronda = new Ronda(ApuestaInicial, [Tomy], mazo);
        Tomy.Activar();
    }
}
