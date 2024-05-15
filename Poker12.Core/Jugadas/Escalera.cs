namespace Poker12.Core.Jugadas;
public class Escalera : IJugada
{
    public string Nombre => "Escalera";

    public byte Prioridad => 6;

    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
            throw new ArgumentException("No hay cartas");
        if (cartas.Count != 5)
            throw new InvalidOperationException("Tienen que ser 5 cartas");

        var ordenadasPorValor = cartas.OrderBy(c => c.Valor).ToList();
        var i = (byte)ordenadasPorValor.First().Valor; // Como estan ordenadas, la primera es la menor
        var valor = (byte)ordenadasPorValor.Last().Valor;
        if (valor == 13 && i == 1)
        {
            valor = 14;
            ordenadasPorValor.RemoveAll(x => x.Valor == EValor.As);
            i = (byte)ordenadasPorValor.First().Valor; // Como estan ordenadas, la primera es la menor
            return ordenadasPorValor.TrueForAll(ov => i++ == (byte)ov.Valor && valor == 14) ?
                new Resultado(Prioridad, valor) :
                new Resultado(Prioridad, 0);
        }
        return ordenadasPorValor.TrueForAll(ov => i++ == (byte)ov.Valor) ?
                new Resultado(Prioridad, valor) :
                new Resultado(Prioridad, 0);
    }
}
