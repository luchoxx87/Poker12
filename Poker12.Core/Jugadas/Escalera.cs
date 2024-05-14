namespace Poker12.Core.Jugadas;

public class Escalera : IJugada
{
    public string Nombre => "Escalera";

    public byte Prioridad => 6;

    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
            throw new ArgumentException("No hay cartas");
        var ordenadasPorValor = cartas.OrderBy(c => c.Valor).ToList();
        var i =  (byte)ordenadasPorValor.First().Valor; // Como estan ordenadas, la primera es la menor
        var valor = (byte)ordenadasPorValor.Last().Valor;
        if (valor == 13 && i == 1)
        {
            valor = 14;
            ordenadasPorValor.RemoveAll(x => x.Valor == EValor.As);
            i =  (byte)ordenadasPorValor.First().Valor; // Como estan ordenadas, la primera es la menor
            foreach (var item in ordenadasPorValor)
            {
            if (i != (byte)item.Valor || valor != 14)
                return new Resultado(Prioridad, 0);
            i++;
            }
            return new Resultado(Prioridad, valor);
        }
        foreach (var item in ordenadasPorValor)
        {
            if (i != (byte)item.Valor)
                return new Resultado(Prioridad, 0);
            i++;
        }
        return new Resultado(Prioridad, valor);
    }
}
