namespace Poker12.Core.ColeccionesCartas;
public class NoMezcla : IMezclador
{
    public void MezclarCartas(IEnumerable<Carta> Cartas)
        => Cartas.OrderBy(x => x.Valor);

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
