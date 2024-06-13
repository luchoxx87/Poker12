
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
        List<Carta> Mazo = [];
        foreach (var palos in Enum.GetValues<EPalo>())
        {
            foreach (var valores in Enum.GetValues<EValor>())
            {
                Mazo.Add(new(palos, valores));
            }
        }
        return Mazo;
    }
}
