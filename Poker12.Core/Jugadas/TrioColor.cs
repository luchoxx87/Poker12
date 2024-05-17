namespace Poker12.Core.Jugadas;
public class TrioColor : IJugada
{
    public string Nombre => "Trio Color";
    public byte Prioridad => 7; // Podemos asignarle una prioridad adecuada basada en las reglas del póker
    public Resultado Aplicar(List<Carta> cartas)
    {
        var ordenadaPorValor = cartas.OrderBy(x => x.Valor);
        var ordenar = ordenadaPorValor.Select(x => (byte)x.Valor).ToList();

        bool tieneTrio = false;

        for (int i = 0; i < ordenar.Count - 2; i++)
        {
            // Verificar si los tres elementos son iguales
            if (ordenar[i] == ordenar[i + 1] && ordenar[i + 1] == ordenar[i + 2])
            {
                tieneTrio = true;
            }
        }

        if (!tieneTrio)
            return new Resultado(Prioridad, 0); // Todas las cartas no son del mismo palo
        
        var valor = (byte)ordenadaPorValor.Last().Valor;
        return new Resultado(Prioridad, valor); // Sumamos 10 porque el As vale 1 y queremos evitar conflictos
    }
}
