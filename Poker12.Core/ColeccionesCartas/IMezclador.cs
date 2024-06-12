namespace Poker12.Core.ColeccionesCartas;
public interface IMezclador
{
    IEnumerable<Carta> ObtenerCartas();
    IEnumerable<Carta> MezclarCartas(IEnumerable<Carta> Cartas);
}
