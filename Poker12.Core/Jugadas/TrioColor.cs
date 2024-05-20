namespace Poker12.Core.Jugadas;
public class TrioColor : IJugada
{
    public string Nombre => "Trio Color";
    public byte Prioridad => 7; 
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count < 3)
            throw new ArgumentException("Necesitas al menos 3 cartas para jugar un Trio Color");
        var tripleValue = cartas.GroupBy(c => c.Valor).FirstOrDefault(g => g.Count() == 3)?.Key;
        if (tripleValue.HasValue)
        {
            return new Resultado(Prioridad, tripleValue.Value == EValor.As ? (byte)14 : (byte)tripleValue.Value);
        }
        return new Resultado(Prioridad, 0); 
    }
}