
namespace Poker12.Core.Jugadas;

public abstract class JugadaAbs : IJugada
{
    static protected int CantidadCartas = 5;
    public string Nombre { get; init; }
    private JugadaAbs? _siguiente { get; init; }
    public byte Prioridad { get; init; }
    protected JugadaAbs(string nombre, byte prioridad, JugadaAbs? siguiente = null)
        => (Nombre, Prioridad, _siguiente) = (nombre, prioridad, siguiente);
    public Resultado Cero => new Resultado(Prioridad);
    
    public Resultado ResultadoCon(byte valor) => new Resultado(Prioridad, valor);

    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count < CantidadCartas)
            throw new ArgumentException("No alcanzan las cartas");
        var cartasJugada = new CartasJugada(cartas);
        return Aplicar(cartasJugada);
    }

    protected virtual Resultado Aplicar(CartasJugada cartas)
    {
        //Por defecto lo delega al siguiente
        if (_siguiente is null)
            throw new InvalidOperationException("No hay posibilidad");

        return _siguiente.Aplicar(cartas);
    }
}
