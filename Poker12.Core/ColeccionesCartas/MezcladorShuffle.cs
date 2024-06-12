
namespace Poker12.Core.ColeccionesCartas;

public class MezcladorShuffle : IMezclador
{
    public void MezclarCartas(IEnumerable<Carta> Cartas)
    {
        var rmd = new Random();
        Cartas = Cartas.OrderBy(x => rmd.Next());
    }

    public IEnumerable<Carta> ObtenerCartas()
    {
        List<Carta> cartas = new List<Carta>();

        foreach (EPalo palo in Enum.GetValues<EPalo>())
        {
            foreach (EValor valor in Enum.GetValues<EValor>())
            {
                cartas.Add(new Carta(palo, valor));
            }
        }

        return cartas;
    }
}
