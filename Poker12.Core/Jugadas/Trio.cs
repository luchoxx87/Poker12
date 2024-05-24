namespace Poker12.Core.Jugadas;
public class Trio : JugadaAbs
{
    public Trio(string nombre, byte prioridad, JugadaAbs? siguiente = null) : base(nombre, prioridad, siguiente)
    {
    }
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count < 3)
            throw new ArgumentException("Necesitas al menos 3 cartas para jugar un Trio Color");
        var groups = cartas.GroupBy(c => c.Valor).Where(g => g.Count() == 3);
        if (groups.Any())
        {
            var highestValue = groups.Max(g => g.Key);
            return new Resultado(Prioridad, highestValue == EValor.As? (byte)14 : (byte)highestValue);
        }
        return new Resultado(Prioridad, 0); 
    }

    protected override Resultado Aplicar(CartasJugada cartas)
    {
        

        return base.Aplicar(cartas);
    }
}
