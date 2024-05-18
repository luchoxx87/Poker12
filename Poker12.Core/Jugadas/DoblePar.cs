namespace Poker12.Core.Jugadas;
public class DoblePar : IJugada
{
    public string Nombre => "Doble Par";
    public byte Prioridad => 7; 
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count < 4)
            throw new ArgumentException("Necesitas al menos 4 cartas para jugar un Doble Par");

        var valores = cartas.Select(c => c.Valor).ToList();
        var conteoValores = valores.GroupBy(v => v).ToDictionary(g => g.Key, g => g.Count());
        var parejas = conteoValores.Where(p => p.Value == 2).Select(p => p.Key).ToList();
        if (parejas.Count!= 2)
            return new Resultado(Prioridad, 0);
        var primerPar = parejas[0];
        var segundoPar = parejas[1];
        if (primerPar == segundoPar)
            return new Resultado(Prioridad, (byte)(primerPar + 9)); 
        return new Resultado(Prioridad, 0);
    }
}
