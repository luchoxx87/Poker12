namespace Poker12.Core.Jugadas;
public interface IJugada
{
    public string Nombre { get; }
    public byte? Valor { get; }
    public bool PuedeAplicar (List<Carta> cartas);
}
