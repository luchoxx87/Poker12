
namespace Poker12.Core.ColeccionesCartas;

public class MezcladorShuffle : IMezclador
{
    public IEnumerable<Carta> MezclarCartas(IEnumerable<Carta> Cartas)
    {
        var rmd = new Random();
        var cartasMezclado = Cartas.OrderBy(x => rmd.Next());

        return cartasMezclado;
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
