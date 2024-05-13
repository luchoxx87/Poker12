
namespace Poker12.Core.Jugadas;

public class Escalera : IJugada
{
    public string Nombre => "Escalera";

    public byte Prioridad => 6;

    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
            throw new ArgumentException("No hay cartas");
        var ordenadasPorValor = cartas.OrderBy(c => c.Valor);
        var valormax = (byte)ordenadasPorValor.Last().Valor;
        var valormin = (byte)ordenadasPorValor.First().Valor; // Como estan ordenadas, la primera es la menor
        byte i = 0;
        if (cartas.Find())
        {
            valormax = ordenadasPorValor.First().Valor == EValor.As ?
                            (byte)14 : // Aca use el valor 'Alto' del As
                            (byte)ordenadasPorValor.Last().Valor; // Como estan ordenadas, la ultima es la mayor
        }

        
        i = valormin;
        foreach (var item in cartas)
        {
            if (i != ((byte)item.Valor))
                return new Resultado(Prioridad, 0);
            i++;
        }
        return new Resultado(Prioridad, valormax);
    }
}