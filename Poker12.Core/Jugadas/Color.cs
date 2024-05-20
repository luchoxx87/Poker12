
namespace Poker12.Core.Jugadas;

public class Color : IJugada
{
    public string Nombre => "Color";

    public byte Prioridad => 5;

    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
            throw new ArgumentException("No hay cartas");
        if (cartas.Count != 5)
            throw new InvalidOperationException("Tienen que ser 5 cartas");

        var ordenadasPorValor = cartas.OrderBy(c => c.Valor);

        var valor = ordenadasPorValor.First().Valor == EValor.As ?
                        (byte)14 : // Aca use el valor 'Alto' del As
                        (byte)ordenadasPorValor.Last().Valor; // Como estan ordenadas, la ultima es la mayor 

        return cartas.TrueForAll(ov => ordenadasPorValor.First().Palo.ToString() == ov.Palo.ToString()) ?
                new Resultado(Prioridad, valor) :
                new Resultado(Prioridad, 0);
    }
}