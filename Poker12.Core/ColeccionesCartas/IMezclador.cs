namespace Poker12.Core.ColeccionesCartas;
public interface IMezclador
{
    IEnumerable<Carta> ObtenerCartas();
    void MezclarCartas(IEnumerable<Carta> Cartas);
}
