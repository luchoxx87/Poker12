
namespace Poker12.Core.ColeccionesCartas;

public class Mezclador : IMezclador
{
    public void MezclarCartas(IEnumerable<Carta> Cartas)
    {
        foreach (Carta i in Cartas)
        {
            
        }
    }

    public IEnumerable<Carta> ObtenerCartas()
    {
        throw new NotImplementedException();
    }
}