namespace Poker12.Core.Jugadas;
public class TrioColor : IJugada
{
    public string Nombre => "Trio Color";
    public byte Prioridad => 7; 
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count < 3)
            throw new ArgumentException("Necesitas al menos 3 cartas para jugar un Trio Color");
        var cartaByte = cartas.Select(c => (byte)c.Valor).ToList(); 
        var counts = new Dictionary<byte, int>();
        foreach (var valor in cartaByte)
        {
            if (!counts.ContainsKey(valor))
                counts[valor] = 1;
            else
                counts[valor]++;
        }
        foreach (var count in counts.Values)
        {
            if (count == 3)
            {
                var highestValue = counts.FirstOrDefault(pair => pair.Value == 3).Key;
                return new Resultado(Prioridad, highestValue == 1? (byte)14 : highestValue); 
            }
        }
        return new Resultado(Prioridad, 0); 
    }
}
