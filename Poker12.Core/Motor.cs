using Poker12.Core.ColeccionesCartas;

namespace Poker12.Core;

public class Motor : IDisposable
{
    public List<Jugador> Jugadores { get; private set; } = [];
    public int IndiceMano { get; set; } = 0;
    public IMezclador Mezclador { get; set; }
    public ushort FichasIniciales { get; set; }
    public int Ronda { get; set; }
    public Mazo Mazo { get; set; }
    public Motor(IMezclador mezclador)
    {
        Mezclador = mezclador;
        Mazo = new Mazo(Mezclador.ObtenerCartas());
    }
    public void Iniciar()
    {

    }
    public void Dispose()
        => Jugadores.Clear();

    public void SacarJugador(Jugador jugador)
        => jugador.Activo = false;
}
