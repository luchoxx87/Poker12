
namespace Poker12.Core.Jugadas;

public class Color : IJugada
{
    public string Nombre => "Color";

    public byte Prioridad => 5;

    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
            throw new ArgumentException("No hay cartas");
        var ordenadasPorValor = cartas.OrderBy(c => c.Valor);

        var valor = ordenadasPorValor.First().Valor == EValor.As ?
                        (byte)14 : // Aca use el valor 'Alto' del As
                        (byte)ordenadasPorValor.Last().Valor; // Como estan ordenadas, la ultima es la mayor 

        string primer_color = cartas.First().Palo.ToString();

        foreach (var item in cartas)
        {
            if (primer_color != item.Palo.ToString())
                return new Resultado(Prioridad, 0);

        }
        return new Resultado(Prioridad, valor);
    }
}